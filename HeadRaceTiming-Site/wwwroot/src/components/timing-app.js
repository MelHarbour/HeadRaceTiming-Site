import { LitElement, html } from 'lit-element';
import { connect } from 'pwa-helpers/connect-mixin';
import { installRouter } from 'pwa-helpers/router';
import { updateMetadata } from 'pwa-helpers/metadata';
import { MDCTopAppBar } from "@material/top-app-bar/index";
import { MDCTextField } from "@material/textfield";
import { MDCRipple } from "@material/ripple";

import { store } from '../store';

import {
    navigate,
    updateSearch,
    applySearch
} from '../actions/app';

import competitions from '../reducers/competitions';
store.addReducers({
    competitions
});

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
                    ${this._showSearch ? html`
                    <section class="mdc-top-app-bar__section mdc-top-app-bar__section--align-start">
                        <button @click="${() => this.searchClickHandler()}" class="mdc-icon-button mdc-top-app-bar__navigation-icon material-icons" aria-label="Back">arrow_back</button>
                        <div class="mdc-text-field mdc-text-field--fullwidth">
                            <input class="mdc-text-field__input mdc-typography--headline6" type="text" placeholder="Search" aria-label="Search" @input="${(event) => this.searchTextHandler(event)}">
                        </div>
                    </section>
                    ` : html`
                    <section class="mdc-top-app-bar__section mdc-top-app-bar__section--align-start">
                        <span class="mdc-top-app-bar__title">${this.appTitle}${this._filterAward ? html` - ${this._filterAward.title}` : null}</span >
                        ${this._page === 'results' ? html`
                        <results-menu ?active="${this._page === 'results'}"></results-menu>
                        ` : null}
                    </section>
                    ${this._page === 'results' ? html`
                    <section class="mdc-top-app-bar__section mdc-top-app-bar__section--align-end" role="toolbar">
                            <button @click="${() => this.searchClickHandler()}" class="mdc-icon-button mdc-top-app-bar__action-item material-icons" aria-label="Search">search</button>
                            <a href="/Competition/DetailsAsCsv/${this._competition.competitionId}" download class="material-icons mdc-top-app-bar__action-item mdc-icon-button" aria-label="Download" alt="Download">cloud_download</a>
                            <a href="#" @click="${(event) => this.infoClickHandler(event)}" class="material-icons mdc-top-app-bar__action-item mdc-icon-button" aria-label="Info" alt="Info">info</a>
                            <basic-dialog><div slot="content">${this._competition.dialogInformation}</div></basic-dialog>
                    </section>
                    `: null}
                    `}
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
            _competition: { type: Object },
            _showSearch: { type: Boolean },
            _filterAward: { type: Object }
        };
    }

    firstUpdated() {
        installRouter((location) => store.dispatch(navigate(decodeURIComponent(location.pathname))));
        const topAppBar = new MDCTopAppBar(this.shadowRoot.querySelector('.mdc-top-app-bar'));
    }

    updated(changedProps) {
        if (changedProps.has('_page')) {
            const pageTitle = this.appTitle + ' - ' + this._page;
            updateMetadata({
                title: pageTitle,
                description: pageTitle
            });
        }
        const textFieldElement = this.shadowRoot.querySelector('.mdc-text-field');
        if (textFieldElement) {
            const textField = new MDCTextField(textFieldElement);
            textField.focus();
        }
    }

    stateChanged(state) {
        this._page = state.app.page;
        this._showSearch = state.app.showSearch;
        if (state.app.focussedCompetition) {
            this._competition = state.competitions.competitions[state.competitions.competitionsByFriendlyName[state.app.focussedCompetition]];
        }
        if (state.app.filterAward) {
            this._filterAward = state.awards.awards[state.app.filterAward];
        } else {
            this._filterAward = null;
        }
    }

    searchClickHandler() {
        store.dispatch(updateSearch(!this._showSearch));
    }

    infoClickHandler(event) {
        this.shadowRoot.querySelector('basic-dialog').open();
        event.preventDefault();
    }

    searchTextHandler(event) {
        store.dispatch(applySearch(event.target.value));
    }
}

window.customElements.define('timing-app', TimingApp);
