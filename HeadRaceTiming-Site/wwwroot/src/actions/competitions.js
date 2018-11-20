export const GET_COMPETITIONS = 'GET_COMPETITIONS';

const COMPETITIONS_LIST = [
    {
        "id": 1,
        "title": "WEHoRR 2018",
        "friendlyName": "wehorr2018",
        "backgroundColor": "0000FF",
        "textColor": "FFFFFF"
    }
];

export const getAllCompetitions = () => (dispatch) => {
    dispatch({
        type: GET_COMPETITIONS,
        competitions: COMPETITIONS_LIST
    });
};