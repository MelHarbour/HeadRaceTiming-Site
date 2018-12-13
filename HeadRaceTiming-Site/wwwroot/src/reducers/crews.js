import { RECEIVE_CREWS } from '../actions/crews';
import { RECEIVE_CREW_AWARDS } from '../actions/awards';
import { createSelector } from 'reselect';
import { RECEIVE_PENALTIES } from '../actions/penalties';

const INITIAL_STATE = {
    crews: {},
    orderedCrews: []
};

const crews = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case RECEIVE_CREWS:
            return {
                ...state,
                crews: action.crews.reduce((obj, item) => {
                    obj[item.id] = item;
                    if (state.crews[item.id]) {
                        obj[item.id].awards = state.crews[item.id].awards;
                    }
                    return obj;
                }, {}),
                orderedCrews: action.crews.map(item => item.id)
            };
        case RECEIVE_CREW_AWARDS:
            var crew = {
                ...state.crews[action.crewId],
                awards: action.awards.map(award => award.id)
            };
            return {
                ...state,
                crews: Object.keys(state.crews).reduce(function (result, key) {
                    result[key] = action.crewId !== key ? state.crews[key] : { ...state.crews[key], ...crew };
                    return result;
                }, {})
            };
        case RECEIVE_PENALTIES:
            crew = {
                ...state.crews[action.crewId],
                penalties: action.penalties.map(penalty => penalty.id)
            };
            return {
                ...state,
                crews: Object.keys(state.crews).reduce(function (result, key) {
                    result[key] = action.crewId !== key ? state.crews[key] : { ...state.crews[key], ...crew };
                    return result;
                }, {})
            };
        default:
            return state;
    }
};

export default crews;

export const crewsSelector = state => state.crews && state.crews.crews;
const orderedCrewsSelector = state => state.crews && state.crews.orderedCrews;

export const crewsListSelector = createSelector(
    crewsSelector, orderedCrewsSelector,
    (crews, order) => {
        if (!crews) {
            return;
        }
        return order.map(key => crews[key]);
    }
);