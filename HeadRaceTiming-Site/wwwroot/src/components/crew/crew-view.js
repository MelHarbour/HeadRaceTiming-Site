import { html } from '@polymer/lit-element';
import { PageViewElement } from '../page-view-element.js';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { store } from '../../store.js';

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
}

window.customElements.define('crew-view', CrewView);