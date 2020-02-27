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
                athletes: action.athletes.reduce((obj, item) => {
                    obj[item.id] = item;
                    return obj;
                }, {}),
                athletesByCrew: athletesByCrew(state.athletesByCrew, action)
            };
        default:
            return state;
    }
};

const athletesByCrew = (state, action) => {
    switch (action.type) {
        case RECEIVE_ATHLETES:
            const crewId = action.crewId;
            return {
                ...state,
                [crewId]: action.athletes.map(item => item.id)
            };
        default:
            return state;
    }
}

export default athletes;