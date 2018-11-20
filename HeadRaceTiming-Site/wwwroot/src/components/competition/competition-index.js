import { html } from '@polymer/lit-element';
import { PageViewElement } from '../page-view-element.js';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { store } from '../../store.js';
import { repeat } from 'lit-html/directives/repeat.js';

import competitions from '../../reducers/competitions.js';
import { getAllCompetitions } from '../../actions/competitions.js';
import { navigate } from '../../actions/app.js';
store.addReducers({
    competitions
});


class CompetitionIndex extends connect(store)(PageViewElement) {
  render() {
      return html`
        <link rel="stylesheet" href="/dist/site.css">

        ${this._competitions && repeat(this._competitions, (competition) =>
              html`
        <div @click="${(event) => this.clickHandler(event)}" class="mdc-card competitionCard" style="background-color: #${competition.backgroundColor}" data-competition-id=${competition.friendlyName}>
            <div class="mdc-card__primary-action">
                <div class="mdc-typography--headline6" style="color: #${competition.textColor}">${competition.title}</div>
            </div>
        </div>
       `)}`;
    }

    static get properties() {
        return {
            _competitions: { type: Array }
        };
    }

    firstUpdated() {
        store.dispatch(getAllCompetitions());
    }

    stateChanged(state) {
        this._competitions = state.competitions.competitions;
    }

    clickHandler(event) {
        window.history.pushState({}, '', '/results/' + event.currentTarget.dataset.competitionId);
        store.dispatch(navigate(window.location.pathname));
    }
}

window.customElements.define('competition-index', CompetitionIndex);