import { html } from '@polymer/lit-element';
import { PageViewElement } from '../page-view-element.js';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { store } from '../../store.js';
import { repeat } from 'lit-html/directives/repeat.js';
import { MDCMenu } from '@material/menu';
import { getCompetitionAwards } from '../../actions/awards.js';

import awards from '../../reducers/awards.js';
store.addReducers({
    awards
});

class ResultsMenu extends connect(store)(PageViewElement) {
  render() {
      return html`
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="/dist/site.css">

        <div id="menu" class="mdc-menu-surface--anchor">
            <button class="mdc-icon-button material-icons" @click="${(event) => this.clickHandler(event)}">arrow_drop_down</button>
            <div class="mdc-menu mdc-menu-surface" tabindex="-1">
                <ul class="mdc-list" role="menu" aria-hidden="true" aria-orientation="vertical">
                    <li class="mdc-list-item" role="menuitem">
                        <span class="mdc-list-item__text">Overall</span>
                    </li>
                    ${this._awards && repeat(this._awards, (award) =>
                    html`
                    <li class="mdc-list-item" role="menuitem">
                        <span class="mdc-list-item__text">${award.title}</span>
                    </li>
                    `)}
                </ul>
            </div>
        </div>
        `;
    }
    static get properties() {
        return {
            _menu: { type: Object },
            _awards: { type: Array }
        };
    }

    firstUpdated() {
        this._menu = new MDCMenu(this.shadowRoot.querySelector('.mdc-menu'));
    }

    clickHandler(event) {
        this._menu.open = true;
        event.preventDefault();
        return false;
    }

    stateChanged(state) {
        this._awards = Object.values(state.awards.awards);
    }
}

window.customElements.define('results-menu', ResultsMenu);

export { getCompetitionAwards };