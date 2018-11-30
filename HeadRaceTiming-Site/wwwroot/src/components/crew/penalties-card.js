import { html, LitElement } from '@polymer/lit-element';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { store } from '../../store.js';
import { CardTableStyles } from '../card-table-styles.js';
import { repeat } from 'lit-html/directives/repeat.js';

import penalties from '../../reducers/penalties.js';
import '../basic-card.js';
import { getCrewPenalties } from '../../actions/penalties.js';
store.addReducers({
    penalties
});

class PenaltiesCard extends connect(store)(LitElement) {
    render() {
        return html`
        ${CardTableStyles}
        <basic-card headline="Penalties">
            <table slot="content">
                <thead>
                    <tr><th>Amount</th><th>Reason</th></tr>
                </thead>
                <tbody>
                    
                </tbody>
            </table>
        </basic-card>
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