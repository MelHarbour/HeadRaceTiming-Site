export const RECEIVE_CREWS = 'RECEIVE_CREWS';
export const RECEIVE_CREW = 'RECEIVE_CREW';

export const getCompetitionCrews = (id, awardId, searchString) => (dispatch) => {
    var queryString = (awardId > 0 ? 'award=' + awardId : '')
    if (searchString) {
        if (queryString != '')
            queryString += "&";

        queryString += 's=' + searchString;
    }
    fetch('/api/competitions/' + id + '/crews' + (queryString != '' ? '?' + queryString : ''))
        .then(res => res.json())
        .then(data => dispatch(receiveCrews(data)));
};

export const getCrew = (id) => (dispatch) => {
    fetch('/api/crews/' + id)
        .then(res => res.json())
        .then(data => dispatch(receiveCrew(data)));
}

const receiveCrew = (item) => {
    return {
        type: RECEIVE_CREW,
        crew: item
    }
}

const receiveCrews = (items) => {
    return {
        type: RECEIVE_CREWS,
        crews: items
    };
};