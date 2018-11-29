import { html, LitElement } from '@polymer/lit-element';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { store } from '../../store.js';
import { repeat } from 'lit-html/directives/repeat.js';

import penalties from '../../reducers/penalties.js';
import { getCrewPenalties } from '../../actions/penalties.js';
store.addReducers({
    penalties
});

class PenaltiesCard extends connect(store)(LitElement) {
    render() {
        return html`
        <link rel="stylesheet" href="/dist/site.css">
        <div class="mdc-card">
        <div class="mdc-card__primary-action">
        <div class="mdc-typography--headline6">Penalties</div>
            <table>
                <thead>
                    <tr><th>Amount</th><th>Reason</th></tr>
                </thead>
                <tbody>
                    
                </tbody>
            </table>
        </div>
        </div>
        `;
    }

    static get properties() {
        return {
            crewId: { type: Number },
            _penalties: { type: Array }
        };
    }

    firstUpdated() {
        store.dispatch(getCrewPenalties(this.crewId));
    }

    stateChanged(state) {
        this._penalties = state.penalties.penalties;
    }
}

window.customElements.define('penalties-card', PenaltiesCard);