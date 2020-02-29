import { html } from 'lit-element';
import { PageViewElement } from '../page-view-element';
import { connect } from 'pwa-helpers/connect-mixin';
import { store } from '../../store';
import { repeat } from 'lit-html/directives/repeat';

import crews from '../../reducers/crews';
import competitions from '../../reducers/competitions';
import { crewsListSelector } from '../../reducers/crews';
import { navigate } from '../../actions/app';
import { getCompetitionCrews } from '../../actions/crews';
import { getCompetition } from '../../actions/competitions';
import { setTimeout, clearTimeout } from 'timers';
store.addReducers({
    crews,
    competitions
});

class ResultsView extends connect(store)(PageViewElement) {
  render() {
      return html`
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <style>
            .header-row, .row {
                display: flex;
                line-height: 56px;
                padding-left: 24px;
                padding-right: 24px;
                border-bottom: 1px rgba(0, 0, 0, 0.12) solid;
            }
            .header-row {
                color: rgba(0,0,0,0.54);
            }
            .row {
                color: rgba(0,0,0,0.87);
            }
            .row:hover {
                background-color: #eeeeee;
                cursor: pointer;
            }
            .name {
                flex-grow: 1;
                overflow: hidden;
                text-overflow: ellipsis;
                white-space: nowrap;
            }
            .startNumber {
                width: 33px;
                margin-right: 56px;
            }
            .intermediate, .time {
                width: 100px;
                text-align: center;
                margin-left: 56px;
            }
            .intermediate {
                display: none;
            }
            @media (min-width: 840px) {
                .intermediate {
                    display: block;
                }
            }
        </style>
        <div class="header-row">
            <div class="startNumber">Start</div>
            <div class="name">Crew Name</div>
            <div class="intermediate">${this._firstIntermediateName}</div>
            <div class="intermediate">${this._secondIntermediateName}</div>
            <div class="time">Finish</div>
        </div>
        ${this._crews && repeat(this._crews, (crew) =>
              html`
            <div class="row" @click="${(event) => this.clickHandler(event)}" data-crew-id=${crew.id}>
                <div class="startNumber">
                    ${crew.startNumber}
                </div>
                <div class="name" title="${crew.name}">
                    ${crew.name}
                    ${crew.isFinished ? html`<span class="material-icons">done</span>` :
                        (crew.isStarted ? html`<span class="material-icons">rowing</span>` : null) }
                </div>
                <div class="intermediate">
                    ${crew.status ? null : html`
                        ${this._getTime(crew, this._firstIntermediatePoint)}
                        ${this._getTime(crew, this._firstIntermediatePoint) ? html`
                            (${this._getRank(crew, this._firstIntermediatePoint)})
                        ` : null}
                    `}
                </div>
                <div class="intermediate">
                    ${crew.status ? null : html`
                        ${this._getTime(crew, this._secondIntermediatePoint)}        
                        ${this._getTime(crew, this._secondIntermediatePoint) ? html`
                            (${this._getRank(crew, this._secondIntermediatePoint)})
                        ` : null}
                    `}
                </div>
                <div class="time">
                    ${crew.status
                      ? html`${this._statusCode(crew.status)}`
                      : html`
                            ${crew.overallTime}${crew.hasPenalty ? html`P` : null}
                            ${crew.overallTime ? html`(${crew.rank})` : null}
                    `}
                </div>
            </div>
       `)}
        `;
    }
    static get properties() {
        return {
            _crews: { type: Array },
            _firstIntermediateName: { type: String },
            _secondIntermediateName: { type: String },
            _firstIntermediatePoint: { type: Number },
            _secondIntermediatePoint: { type: Number },
            _timeout: { type: Number },
            _filterAwardId: { type: Number },
            _searchString: { type: String }
        };
    }

    _statusCode(s) {
        switch (s) {
            case 1: return "Missing";
            case 2: return "DNF";
            case 3: return "DSQ";
            case 4: return "DNS";
        }
    }

    _getTime(crew, timingPointId) {
        for (var i = 0; i < crew.results.length; i++) {
            if (crew.results[i].id === timingPointId)
                return crew.results[i].runTime;
        }
    }

    _getRank(crew, timingPointId) {
        for (var i = 0; i < crew.results.length; i++) {
            if (crew.results[i].id === timingPointId)
                return crew.results[i].rank;
        }
    }

    updated() {
        const state = store.getState();
        if (state.app.focussedCompetition && !this._timeout) {
            const competitionId = state.competitions.competitionsByFriendlyName[state.app.focussedCompetition];
            this._timeout = setTimeout(() => {
                store.dispatch(getCompetitionCrews(competitionId, this._filterAwardId, this._searchString));
                this._timeout = null;
                }, 10000);
        }
    }

    stateChanged(state) {
        if (state.app.focussedCompetition) {
            const competitionId = state.competitions.competitionsByFriendlyName[state.app.focussedCompetition];
            if ((state.app.filterAward !== this._filterAwardId || state.app.searchString !== this._searchString)
                && this._timeout !== null) {
                clearTimeout(this._timeout);
                store.dispatch(getCompetitionCrews(competitionId, state.app.filterAward, state.app.searchString));
            }
            this._filterAwardId = state.app.filterAward;
            this._searchString = state.app.searchString;
            if (state.crews.crewsByAward && state.crews.crewsByAward[this._filterAwardId] && state.crews.crewsByAward[this._filterAwardId][this._searchString]) {
                this._crews = state.crews.crewsByAward[this._filterAwardId][this._searchString].map(item => state.crews.crews[item]);
            }
            if (competitionId) {
                this._firstIntermediateName = state.competitions.competitions[competitionId].firstIntermediateName;
                this._firstIntermediatePoint = state.competitions.competitions[competitionId].firstIntermediateId;
                this._secondIntermediateName = state.competitions.competitions[competitionId].secondIntermediateName;
                this._secondIntermediatePoint = state.competitions.competitions[competitionId].secondIntermediateId;
            }
        }
    }

    clickHandler(event) {
        window.history.pushState({}, '', '/crew/' + event.currentTarget.dataset.crewId);
        store.dispatch(navigate(window.location.pathname));
    }
}

window.customElements.define('results-view', ResultsView);

export { getCompetitionCrews, getCompetition };