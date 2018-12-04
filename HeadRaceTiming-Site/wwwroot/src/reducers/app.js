import {
  UPDATE_PAGE,
  UPDATE_OFFLINE,  APPLY_FILTER
} from '../actions/app.js';

const INITIAL_STATE = {
    page: '',
    focussedCrew: '',
    focussedCompetition: '',
    filterAward: '',
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
                      focussedCompetition: action.id
                  };
              case 'crew':
                  return {
                      ...state,
                      page: action.page,
                      focussedCrew: action.id
                  };
              default:
                  return {
                      ...state,
                      page: action.page
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
    default:
      return state;
  }
};

export default app;
