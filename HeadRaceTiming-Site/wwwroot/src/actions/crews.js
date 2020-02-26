export const RECEIVE_CREWS = 'RECEIVE_CREWS';

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

const receiveCrews = (items) => {
    return {
        type: RECEIVE_CREWS,
        crews: items
    };
};