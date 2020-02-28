import { html, LitElement } from 'lit-element';
import { connect } from 'pwa-helpers/connect-mixin';
import { store } from '../../store';
import { repeat } from 'lit-html/directives/repeat';
import { CardTableStyles } from '../card-table-styles';

import results from '../../reducers/results';
import '../basic-card';
import { getCrewResults } from '../../actions/results';
store.addReducers({
    results
});

class ResultsCard extends connect(store)(LitElement) {
    render() {
        return html`
        ${CardTableStyles}
        <basic-card headline="Section Times">
            <table slot="content">
            <tr><th>Point</th><th>Time of Day</th><th>Section Time</th><th>Total Time</th></tr>
            ${this._results && repeat(this._results, (result) =>
                html`
                <tr>
                    <td>${result.name}</td>
                    <td>${result.timeOfDay}</td>
                    <td>${result.sectionTime}</td>
                    <td>${result.runTime ? html`${result.runTime} (${result.rank})` : null}</td>
                </tr>
           `)}
        </table>
        </basic-card>
        `;
    }

    static get properties() {
        return {
            crewId: { type: Number },
            _results: { type: Array }
        };
    }

    firstUpdated() {
        store.dispatch(getCrewResults(this.crewId));
    }

    stateChanged(state) {
        this._results = state.crews.crews[this.crewId].results;
    }
}

window.customElements.define('results-card', ResultsCard);