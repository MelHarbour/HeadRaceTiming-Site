import { html } from 'lit-element';
import { PageViewElement } from '../page-view-element';
import { connect } from 'pwa-helpers/connect-mixin';
import { store } from '../../store';
import { repeat } from 'lit-html/directives/repeat';

import competitions from '../../reducers/competitions';
import { getAllCompetitions } from '../../actions/competitions';
import { navigate } from '../../actions/app';
store.addReducers({
    competitions
});


class CompetitionIndex extends connect(store)(PageViewElement) {
  render() {
      return html`
        <link rel="stylesheet" href="/dist/site.css">
<style>
:host {
    padding: 16px;
}
.mdc-card {
    width: 100%;
    height: 76px;
    cursor: pointer;
    padding: 1rem;
    margin-bottom: 1rem;
}
@media (min-width: 282px) {
    .mdc-card {
        width: 250px;
    }
}
</style>

        ${this._competitions && repeat(this._competitions, (competition) =>
              html`
        <div @click="${(event) => this.clickHandler(event)}" class="mdc-card" style="background-color: #${competition.backgroundHtmlColor}" data-competition-id=${competition.friendlyName}>
            <div class="mdc-card__primary-action">
                <div class="mdc-typography--headline6" style="color: #${competition.textHtmlColor}">${competition.name}</div>
            </div>
        </div>
       `)}`;
    }

    static get properties() {
        return {
            _competitions: { type: Array }
        };
    }

    stateChanged(state) {
        this._competitions = Object.values(state.competitions.competitions);
    }

    clickHandler(event) {
        window.history.pushState({}, '', '/results/' + event.currentTarget.dataset.competitionId);
        store.dispatch(navigate(window.location.pathname));
    }
}

window.customElements.define('competition-index', CompetitionIndex);

export { getAllCompetitions };