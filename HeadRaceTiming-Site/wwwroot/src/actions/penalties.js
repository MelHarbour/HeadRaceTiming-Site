export const RECEIVE_PENALTIES = 'RECEIVE_PENALTIES';

export const getCrewPenalties = (id) => (dispatch) => {
    fetch('/api/crews/'+id+'/penalties')
        .then(res => res.json())
        .then(data => dispatch(receivePenalties(data)));
};

const receivePenalties = (items) => {
    return {
        type: RECEIVE_PENALTIES,
        penalties: items
    };
};