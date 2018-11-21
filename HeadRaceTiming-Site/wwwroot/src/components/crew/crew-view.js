import { html } from '@polymer/lit-element';
import { PageViewElement } from '../page-view-element.js';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { store } from '../../store.js';

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
            <div>${this._name}</div>
            <div>Competition: ${this._competitionName}</div>
            <div>Start Number: ${this._startNumber}</div>
            <div>CRI Max: ${this._criMax}</div>
        </div>
        </div>
       `;
    }

    static get properties() {
        return {
            _name: { type: String},
            _competitionName: { type: String },
            _startNumber: { type: Number },
            _criMax: { type: Number }
        };
    }

    stateChanged(state) {
        this._name = state.name;
    }
}

window.customElements.define('crew-view', CrewView);