import { RECEIVE_AWARDS, RECEIVE_CREW_AWARDS } from '../actions/awards';
import { createSelector } from 'reselect';

const INITIAL_STATE = {
    awards: {},
    orderedAwards: []
};

const awards = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case RECEIVE_AWARDS:
            return {
                ...state,
                awards: action.awards.reduce((obj, item) => {
                    obj[item.id] = item;
                    return obj;
                }, state.awards),
                orderedAwards: action.awards.map(item => item.id)
            };
        case RECEIVE_CREW_AWARDS:
            return {
                ...state,
                awards: action.awards.reduce((obj, item) => {
                    obj[item.id] = item;
                    return obj;
                }, state.awards)
            };
        default:
            return state;
    }
};

export default awards;

export const awardsSelector = state => state.awards && state.awards.awards;
const orderedAwardsSelector = state => state.awards && state.awards.orderedAwards;

export const awardsListSelector = createSelector(
    awardsSelector, orderedAwardsSelector,
    (awards, order) => {
        if (!awards) {
            return;
        }
        return order.map(key => awards[key]);
    }
);