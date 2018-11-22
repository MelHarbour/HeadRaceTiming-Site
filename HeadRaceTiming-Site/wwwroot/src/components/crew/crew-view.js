import { html } from '@polymer/lit-element';
import { PageViewElement } from '../page-view-element.js';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { store } from '../../store.js';
import { crewsSelector } from '../../reducers/crews.js';

import crews from '../../reducers/crews.js';
store.addReducers({
    crews
});

class CrewView extends connect(store)(PageViewElement) {
  render() {
      return html`
        <link rel="stylesheet" href="/dist/site.css">

        <div class="mdc-card">
        <div class="mdc-card__primary-action">
        <div class="mdc-typography--headline6">Crew Details</div>
            <div>${this._crew.name}</div>
            <div>Competition: ${this._competitionName}</div>
            <div>Start Number: ${this._crew.startNumber}</div>
            <div>CRI Max: ${this._crew.criMax}</div>
        </div>
        </div>
       `;
    }

    static get properties() {
        return {
            _crew: { type: Object },
            _competitionName: { type: String }
        };
    }

    stateChanged(state) {
        if (state.app.focussedCrew && crewsSelector(state)[state.app.focussedCrew]) {
            this._crew = crewsSelector(state)[state.app.focussedCrew];
        }
    }
}

window.customElements.define('crew-view', CrewView);