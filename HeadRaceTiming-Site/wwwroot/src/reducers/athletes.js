import { RECEIVE_ATHLETES } from '../actions/athletes';

const INITIAL_STATE = {
    athletes: {},
    athletesByCrew: {}
};

const athletes = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case RECEIVE_ATHLETES:
            return {
                ...state,
                athletes: action.athletes
            };
        default:
            return state;
    }
};

export default athletes;