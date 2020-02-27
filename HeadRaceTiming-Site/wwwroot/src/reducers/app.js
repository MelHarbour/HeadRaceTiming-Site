import {
    UPDATE_PAGE,
    UPDATE_OFFLINE,    APPLY_FILTER,
    UPDATE_SEARCH,
    APPLY_SEARCH
} from '../actions/app';

const INITIAL_STATE = {
    page: '',
    focussedCrew: '',
    focussedCompetition: '',
    filterAward: '',
    searchString: '',
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
        case APPLY_SEARCH:
            return {
                ...state,
                searchString: action.searchString
            }
        case UPDATE_SEARCH:
            return {
                ...state,
                showSearch: action.visible,
                searchString: ''
            };
        default:
            return state;
    }
};

export default app;