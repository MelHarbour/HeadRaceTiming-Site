import { html } from '@polymer/lit-element';

export const CardTableStyles = html`
<style>
table {
    border-spacing: 0;
    border-collapse: collapse;
    width: 100%;
}

tr, td {
    border-bottom: 1px rgba(0, 0, 0, 0.12) solid;
}

tr {
    height: 48px;
}

td, th {
    text-align: left;
    padding-left: 56px;
    white-space: nowrap;
}

td:first-child, th:first-child {
    padding-left: 24px;
}

td:last-child, th:last-child {
    padding-right: 24px;
}
</style>
`;