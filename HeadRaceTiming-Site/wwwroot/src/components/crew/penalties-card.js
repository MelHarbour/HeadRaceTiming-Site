import { html, LitElement } from '@polymer/lit-element';
import { connect } from 'pwa-helpers/connect-mixin';
import { store } from '../../store';
import { CardTableStyles } from '../card-table-styles';
import { repeat } from 'lit-html/directives/repeat';

import penalties from '../../reducers/penalties';
import '../basic-card';
import { getCrewPenalties } from '../../actions/penalties';
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
                    ${this._penalties && repeat(this._penalties, (penalty) =>
                    html`
                    <tr><td>${penalty.value}</td><td>${penalty.reason}</td></tr>
                    `)}
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