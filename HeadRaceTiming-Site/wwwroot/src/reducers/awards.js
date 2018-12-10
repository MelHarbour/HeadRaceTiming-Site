import { RECEIVE_AWARDS } from '../actions/awards';

const INITIAL_STATE = {
    awards: {},
    awardsForCompetition: {},
    awardsForCrew: {}
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