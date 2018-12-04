export const RECEIVE_CREWS = 'RECEIVE_CREWS';

export const getCompetitionCrews = (id, awardId) => (dispatch) => {
    fetch('/api/competitions/'+id+'/crews' + (awardId > 0 ? '?award='+awardId : ''))
        .then(res => res.json())
        .then(data => dispatch(receiveCrews(data)));
};

const receiveCrews = (items) => {
    return {
        type: RECEIVE_CREWS,
        crews: items
    };
};