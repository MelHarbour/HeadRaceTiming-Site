import { RECEIVE_PENALTIES } from '../actions/penalties';

const INITIAL_STATE = {
    penalties: {},
    penaltiesForCrew: {}
};

const penalties = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case RECEIVE_PENALTIES:
            return {
                ...state,
                penalties: action.penalties
            };
        default:
            return state;
    }
};

export default penalties;