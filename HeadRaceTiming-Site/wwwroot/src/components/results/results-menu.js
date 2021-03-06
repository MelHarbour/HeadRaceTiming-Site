import { html } from 'lit-element';
import { PageViewElement } from '../page-view-element';
import { connect } from 'pwa-helpers/connect-mixin';
import { store } from '../../store';
import { repeat } from 'lit-html/directives/repeat';
import { MDCMenu } from '@material/menu';
import { getCompetitionAwards } from '../../actions/awards';
import { awardsListSelector } from '../../reducers/awards';
import { applyFilter } from '../../actions/app';

import awards from '../../reducers/awards';
store.addReducers({
    awards
});

class ResultsMenu extends connect(store)(PageViewElement) {
  render() {
      return html`
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="/dist/site.css">

        <div id="menu" class="mdc-menu-surface--anchor">
            <button class="mdc-icon-button material-icons" @click="${() => this.clickHandler()}">arrow_drop_down</button>
            <div class="mdc-menu mdc-menu-surface" tabindex="-1">
                <ul class="mdc-list" role="menu" aria-hidden="true" aria-orientation="vertical" tabindex="-1">
                    <li class="mdc-list-item" role="menuitem">
                        <span class="mdc-list-item__text">Overall</span>
                    </li>
                    ${this._awards && repeat(this._awards, (award) =>
                    html`
                    <li class="mdc-list-item" role="menuitem" data-award-id=${award.id}>
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
        const menuEl = this.shadowRoot.querySelector('.mdc-menu');
        this._menu = new MDCMenu(menuEl);

        menuEl.addEventListener('MDCMenu:selected', this.menuSelected);
    }

    clickHandler() {
        this._menu.open = !this._menu.open;
    }

    stateChanged(state) {
        this._awards = awardsListSelector(state);
    }

    menuSelected(event) {
        var detail = event.detail;
        if (detail.index > 0) {
            store.dispatch(applyFilter(detail.item.dataset.awardId));
        } else {
            store.dispatch(applyFilter(''));
        }
    }
}

window.customElements.define('results-menu', ResultsMenu);

export { getCompetitionAwards };