(window.webpackJsonp=window.webpackJsonp||[]).push([[9],{377:function(t,e,n){"use strict";var o,i,a=function(){function t(t,e){for(var n=0;n<e.length;n++){var o=e[n];o.enumerable=o.enumerable||!1,o.configurable=!0,"value"in o&&(o.writable=!0),Object.defineProperty(t,o.key,o)}}return function(e,n,o){return n&&t(e.prototype,n),o&&t(e,o),e}}(),c=(o=['\n            <link rel="stylesheet" href="/dist/site.css">\n            <div class="mdc-dialog"\n                role="alertdialog"\n                aria-modal="true">\n            <div class="mdc-dialog__container">\n                <div class="mdc-dialog__surface">\n                    <div class="mdc-dialog__content" id="my-dialog-content">\n                        <slot name="content"></slot>\n                    </div>\n                    <footer class="mdc-dialog__actions">\n                        <button type="button" class="mdc-button mdc-dialog__button" data-mdc-dialog-action="accept">Ok</button>\n                    </footer>\n                </div>\n            </div>\n            <div class="mdc-dialog__scrim"></div>\n            </div>\n        '],i=['\n            <link rel="stylesheet" href="/dist/site.css">\n            <div class="mdc-dialog"\n                role="alertdialog"\n                aria-modal="true">\n            <div class="mdc-dialog__container">\n                <div class="mdc-dialog__surface">\n                    <div class="mdc-dialog__content" id="my-dialog-content">\n                        <slot name="content"></slot>\n                    </div>\n                    <footer class="mdc-dialog__actions">\n                        <button type="button" class="mdc-button mdc-dialog__button" data-mdc-dialog-action="accept">Ok</button>\n                    </footer>\n                </div>\n            </div>\n            <div class="mdc-dialog__scrim"></div>\n            </div>\n        '],Object.freeze(Object.defineProperties(o,{raw:{value:Object.freeze(i)}}))),r=n(144),l=n(397);var d=function(t){function e(){return function(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}(this,e),function(t,e){if(!t)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!e||"object"!=typeof e&&"function"!=typeof e?t:e}(this,(e.__proto__||Object.getPrototypeOf(e)).apply(this,arguments))}return function(t,e){if("function"!=typeof e&&null!==e)throw new TypeError("Super expression must either be null or a function, not "+typeof e);t.prototype=Object.create(e&&e.prototype,{constructor:{value:t,enumerable:!1,writable:!0,configurable:!0}}),e&&(Object.setPrototypeOf?Object.setPrototypeOf(t,e):t.__proto__=e)}(e,r.LitElement),a(e,[{key:"render",value:function(){return(0,r.html)(c)}},{key:"open",value:function(){this._dialog.open()}},{key:"firstUpdated",value:function(){this._dialog=new l.MDCDialog(this.shadowRoot.querySelector(".mdc-dialog"))}}],[{key:"properties",get:function(){return{_dialog:{type:Object}}}}]),e}();customElements.define("basic-dialog",d)}}]);