export const UPDATE_PAGE = 'UPDATE_PAGE';
export const APPLY_FILTER = 'APPLY_FILTER';
export const UPDATE_SEARCH = 'UPDATE_SEARCH';
export const APPLY_SEARCH = 'APPLY_SEARCH';

export const navigate = (path) => (dispatch) => {
    // Extract the page name from path.
    const parts = path.slice(1).split('/');
    const page = parts[0] || 'competition';
    const id = parts[1];
    dispatch(loadPage(page, id));
};

const loadPage = (page, id) => async (dispatch, getState) => {
    let module, menuModule;
    const state = getState();
    switch(page) {
        case 'results':
            module = await import('../components/results/results-view.js');
            menuModule = await import('../components/results/results-menu.js');
            await import('../components/basic-dialog.js');
            const awardId = state.app.filterAward;
            const searchString = state.app.searchString;
            if (!state.competitions || !state.competitions.competitionsByFriendlyName || !state.competitions.competitionsByFriendlyName[id]) {
                dispatch(module.getCompetition(id)).then(() => {
                    const competitionId = getState().competitions.competitionsByFriendlyName[id];
                    dispatch(module.getCompetitionCrews(competitionId, awardId, searchString));
                });
                break;
            }
            const competitionId = getState().competitions.competitionsByFriendlyName[id];
            await dispatch(module.getCompetitionCrews(competitionId, awardId, searchString));
            await dispatch(menuModule.getCompetitionAwards(competitionId));
            break;
        case 'competition':
            module = await import('../components/competition/competition-index.js');
            await dispatch(module.getAllCompetitions());
            break;
        case 'crew':
            module = await import('../components/crew/crew-view.js');
            if (!state.app.crews) {
                await dispatch(module.getCrew(id));
            }
            if (!state.app.focussedCrew) {
                state.app.focussedCrew = id;
            }
            await dispatch(module.getCrewAthletes(id));
            await dispatch(module.getCrewPenalties(id));
            await dispatch(module.getCrewAwards(id));
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

export const applyFilter = (awardId) => {
    return {
        type: APPLY_FILTER,
        awardId
    };
};

export const applySearch = (searchString) => {
    return {
        type: APPLY_SEARCH,
        searchString
    };
}

export const updateSearch = (visible) => {
    return {
        type: UPDATE_SEARCH,
        visible
    };
};