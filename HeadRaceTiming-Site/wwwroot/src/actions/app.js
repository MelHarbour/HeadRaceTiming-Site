export const UPDATE_PAGE = 'UPDATE_PAGE';
export const UPDATE_OFFLINE = 'UPDATE_OFFLINE';

export const navigate = (path) => (dispatch) => {
  // Extract the page name from path.
    const parts = path.slice(1).split('/');
    const page = parts[0] || 'competition';
    const id = parts[1];
  dispatch(loadPage(page, id));
};

const loadPage = (page, id) => (dispatch) => {
  switch(page) {
      case 'results':
        require('../components/results/results-view.js');
        break;
      case 'competition':
          require('../components/competition/competition-index.js');
          break;
      case 'crew':
          require('../components/crew/crew-view.js');
          break;
    default:
      page = 'view404';
      require('../components/my-view404.js');
  }

  dispatch(updatePage(page, id));
};

const updatePage = (page, id) => {
  return {
    type: UPDATE_PAGE,
      page: page,
    id : id
  };
};

export const updateOffline = (offline) => (dispatch, getState) => {
  dispatch({
    type: UPDATE_OFFLINE,
    offline
  });
};
