import { html, LitElement } from '@polymer/lit-element';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { store } from '../../store.js';
import { repeat } from 'lit-html/directives/repeat.js';
import { CardTableStyles } from '../card-table-styles.js';

import results from '../../reducers/results.js';
import { getCrewResults } from '../../actions/results.js';
store.addReducers({
    results
});

class ResultsCard extends connect(store)(LitElement) {
    render() {
        return html`
        <link rel="stylesheet" href="/dist/site.css">
        ${CardTableStyles}
        <div class="mdc-card">
        <div class="mdc-card__primary-action">
        <div class="mdc-typography--headline6">Section Times</div>
            <table>
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
        </div>
        </div>
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
        this._results = state.results.results;
    }
}

window.customElements.define('results-card', ResultsCard);