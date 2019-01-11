import { html, LitElement } from 'lit-element';
import { connect } from 'pwa-helpers/connect-mixin';
import { store } from '../../store';
import { CardTableStyles } from '../card-table-styles';
import { repeat } from 'lit-html/directives/repeat';

import awards from '../../reducers/awards';
import '../basic-card';
import { getCrewAwards } from '../../actions/awards';
store.addReducers({
    awards
});

class AwardsCard extends connect(store)(LitElement) {
    render() {
        return html`
        ${CardTableStyles}
        <basic-card headline="Awards">
            <table slot="content">
                <thead>
                    <tr><th>Title</th></tr>
                </thead>
                <tbody>
                    ${this._awards && repeat(this._awards, (award) =>
                    html`
                    <tr><td>${award.title}</td></tr>
                    `)}
                </tbody>
            </table>
        </basic-card>
        `;
    }

    static get properties() {
        return {
            crewId: { type: Number },
            _awards: { type: Array }
        };
    }

    stateChanged(state) {
        const crew = state.crews.crews[this.crewId];
        if (crew && crew.awards) {
            this._awards = crew.awards.map(awardId => state.awards.awards[awardId]);
        }
    }
}

window.customElements.define('awards-card', AwardsCard);