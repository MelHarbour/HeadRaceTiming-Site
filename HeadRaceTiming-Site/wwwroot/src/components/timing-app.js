import { LitElement, html } from '@polymer/lit-element';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { installOfflineWatcher } from 'pwa-helpers/network.js';
import { installRouter } from 'pwa-helpers/router.js';
import { updateMetadata } from 'pwa-helpers/metadata.js';
import { MDCTopAppBar } from "@material/top-app-bar/index";

import { store } from '../store.js';

import {
  navigate,
  updateOffline
} from '../actions/app.js';

class TimingApp extends connect(store)(LitElement) {
    render() {
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
                        ${this._page === 'results' ? html`
                        <button class="mdc-icon-button material-icons">arrow_drop_down</button>
                        <results-menu ?active="${this._page === 'results'}"></results-menu>
                        ` : null}
                    </section>
                    ${this._page === 'results' ? html`
                    <section class="mdc-top-app-bar__section mdc-top-app-bar__section--align-end" role="toolbar">
                        <a href="#" @click="${(event) => this.clickHandler(event)}" class="material-icons mdc-top-app-bar__action-item" aria-label="Download" alt="Download">cloud_download</a>
                        <a href="#" class="material-icons mdc-top-app-bar__action-item" aria-label="Info" alt="Info">info</a>
                    </section>
                    `: null}
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
            _offline: { type: Boolean }
        };
    }

    firstUpdated() {
        installRouter((location) => store.dispatch(navigate(decodeURIComponent(location.pathname))));
        installOfflineWatcher((offline) => store.dispatch(updateOffline(offline)));
        const topAppBarElement = this.shadowRoot.querySelector('.mdc-top-app-bar');
        const topAppBar = new MDCTopAppBar(topAppBarElement);
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
    }

    clickHandler(event) {
        const state = store.getState();
        if (state.app.focussedCompetition) {
            const competitionId = state.competitions.competitionsByFriendlyName[state.app.focussedCompetition];
            window.history.pushState({}, '', '/Competition/DetailsAsCsv/' + competitionId);
            store.dispatch(navigate(window.location.pathname));
        }
    }
}

window.customElements.define('timing-app', TimingApp);
