export const UPDATE_PAGE = 'UPDATE_PAGE';
export const UPDATE_OFFLINE = 'UPDATE_OFFLINE';

export const navigate = (path) => (dispatch) => {
    // Extract the page name from path.
    const parts = path.slice(1).split('/');
    const page = parts[0] || 'competition';
    const id = parts[1];
    dispatch(loadPage(page, id));
};

const loadPage = (page, id) => async (dispatch, getState) => {
    let module, menuModule;
    switch(page) {
        case 'results':
            module = await import('../components/results/results-view.js');
            menuModule = await import('../components/results/results-menu.js');
            const state = getState();
            if (!state.competitions || !state.competitions.competitionsByFriendlyName || !state.competitions.competitionsByFriendlyName[id]) {
                dispatch(module.getCompetition(id)).then(() => {
                    const competitionId = getState().competitions.competitionsByFriendlyName[id];
                    dispatch(module.getCompetitionCrews(competitionId));
                });
                break;
            }
            const competitionId = getState().competitions.competitionsByFriendlyName[id];
            await dispatch(module.getCompetitionCrews(competitionId));
            await dispatch(menuModule.getCompetitionAwards(competitionId));
            break;
        case 'competition':
            module = await import('../components/competition/competition-index.js');
            await dispatch(module.getAllCompetitions());
            break;
        case 'crew':
            module = await import('../components/crew/crew-view.js');
            await dispatch(module.getCrewAthletes(id));
            break;
        default:
            page = 'view404';
            await import('../components/my-view404.js');
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
