import { LitElement, html } from '@polymer/lit-element';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { installOfflineWatcher } from 'pwa-helpers/network.js';
import { installRouter } from 'pwa-helpers/router.js';
import { updateMetadata } from 'pwa-helpers/metadata.js';

// This element is connected to the Redux store.
import { store } from '../store.js';

// These are the actions needed by this element.
import {
  navigate,
  updateOffline
} from '../actions/app.js';

class TimingApp extends connect(store)(LitElement) {
  render() {
    // Anything that's related to rendering should be done in here.
      return html`
    <link rel="stylesheet" href="/dist/site.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <style>
      main {
        display: block;
      }
      main .page {
        display: none;
      }
      main .page[active] {
        display: block;
      }
    </style>

    <header class="mdc-top-app-bar">
        <div class="mdc-top-app-bar__row">
            <section class="mdc-top-app-bar__section mdc-top-app-bar__section--align-start">
                <a href="#" class="material-icons mdc-top-app-bar__navigation-icon">menu</a>
                <span class="mdc-top-app-bar__title">${this.appTitle}</span>
            </section>
        </div>
    </header>
    <main role="main" class="mdc-top-app-bar--fixed-adjust">
        <competition-index class="page" ?active="${this._page === 'competition'}"></competition-index>
        <results-view class="page" ?active="${this._page === 'results'}"></results-view>
        <crew-view class="page" ?active="${this._page === 'crew'}"></crew-view>
    </main>
    `;
  }

  static get properties() {
      return {
          appTitle: { type: String },
          _page: { type: String },
          _offline: { type: Boolean },
          _id: { type: String }
      };
  }

  firstUpdated() {
    installRouter((location) => store.dispatch(navigate(decodeURIComponent(location.pathname))));
    installOfflineWatcher((offline) => store.dispatch(updateOffline(offline)));
  }

    updated(changedProps) {
    if (changedProps.has('_page')) {
      const pageTitle = this.appTitle + ' - ' + this._page;
      updateMetadata({
        title: pageTitle,
        description: pageTitle
      });
    }
  }

  stateChanged(state) {
      this._page = state.app.page;
      this._id = state.app.id;
  }
}

window.customElements.define('timing-app', TimingApp);
