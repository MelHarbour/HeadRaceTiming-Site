import { RECEIVE_AWARDS } from '../actions/awards.js';

const INITIAL_STATE = {
    awards: {},
    awardsForCompetition: {}
};

const awards = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case RECEIVE_AWARDS:
            return {
                ...state,
                awards: action.awards
            };
        default:
            return state;
    }
};

export default awards;