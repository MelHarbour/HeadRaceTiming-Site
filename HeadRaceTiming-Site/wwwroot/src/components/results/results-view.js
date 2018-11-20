import { html } from '@polymer/lit-element';
import { PageViewElement } from '../page-view-element.js';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { store } from '../../store.js';

class ResultsView extends connect(store)(PageViewElement) {
  render() {
      return html`
        This should be the results view
       `;
  }
}

window.customElements.define('results-view', ResultsView);