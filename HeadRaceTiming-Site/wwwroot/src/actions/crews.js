export const RECEIVE_CREWS = 'RECEIVE_CREWS';

export const getCompetitionCrews = () => (dispatch) => {
    fetch('/api/competitions/1/crews')
        .then(res => res.json())
        .then(data => dispatch(receiveCrews(data)));
};

const receiveCrews = (items) => {
    return {
        type: RECEIVE_CREWS,
        crews: items
    };
};