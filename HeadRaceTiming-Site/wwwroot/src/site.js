import { MDCTopAppBar } from '@material/top-app-bar/index';
import { MDCDialog } from '@material/dialog/index';

const topAppBarElement = document.querySelector('.mdc-top-app-bar');
const topAppBar = new MDCTopAppBar(topAppBarElement);

window.dialog = new MDCDialog(document.querySelector('.mdc-dialog'));