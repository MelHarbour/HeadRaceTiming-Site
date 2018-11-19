import { html } from '@polymer/lit-element';
import { PageViewElement } from './page-view-element.js';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { store } from '../store.js';
import { repeat } from 'lit-html/directives/repeat.js';

import competitions from '../reducers/competitions.js';
import { getAllCompetitions } from '../actions/competitions.js';
store.addReducers({
    competitions
});


class MyView1 extends connect(store)(PageViewElement) {
  render() {
      return html`
        <link rel="stylesheet" href="/dist/site.css">

        ${this._competitions.competitions && repeat(this._competitions.competitions, (competition) =>
              html`
        <div class="mdc-card competitionCard" style="background-color: #${competition.backgroundColor}" data-competition-id=${competition.friendlyName}>
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
        this._competitions = state.competitions;
    }
}

window.customElements.define('my-view1', MyView1);