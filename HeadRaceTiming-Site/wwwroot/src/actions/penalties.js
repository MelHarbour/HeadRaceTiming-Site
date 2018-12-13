export const RECEIVE_PENALTIES = 'RECEIVE_PENALTIES';

export const getCrewPenalties = (id) => (dispatch) => {
    fetch('/api/crews/'+id+'/penalties')
        .then(res => res.json())
        .then(data => dispatch(receiveCrewPenalties(data, id)));
};

const receiveCrewPenalties = (items, id) => {
    return {
        type: RECEIVE_PENALTIES,
        penalties: items,
        crewId: id
    };
};