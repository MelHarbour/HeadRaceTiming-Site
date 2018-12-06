import {
    UPDATE_PAGE,
    UPDATE_OFFLINE,    APPLY_FILTER,
    SHOW_SEARCH
} from '../actions/app.js';

const INITIAL_STATE = {
    page: '',
    focussedCrew: '',
    focussedCompetition: '',
    filterAward: '',
    showSearch: false,
    offline: false
};

const app = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case UPDATE_PAGE:
            switch (action.page) {
                case 'results':
                    return {
                        ...state,
                        page: action.page,
                        focussedCompetition: action.id,
                        showSearch: false
                    };
                case 'crew':
                    return {
                        ...state,
                        page: action.page,
                        focussedCrew: action.id,
                        showSearch: false
                    };
                default:
                    return {
                        ...state,
                        page: action.page,
                        showSearch: false
                    };
            }
        case UPDATE_OFFLINE:
            return {
                ...state,
                offline: action.offline
            };
        case APPLY_FILTER:
            return {
                ...state,
                filterAward: action.awardId
            };
        case SHOW_SEARCH:
            return {
                ...state,
                showSearch: true
            };
        default:
            return state;
    }
};

export default app;