(window.webpackJsonp=window.webpackJsonp||[]).push([[5],{374:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.getCompetitionAwards=void 0;var r,i=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),o=w(['\n        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">\n        <link rel="stylesheet" href="/dist/site.css">\n\n        <div id="menu" class="mdc-menu-surface--anchor">\n            <button class="mdc-icon-button material-icons" @click="','">arrow_drop_down</button>\n            <div class="mdc-menu mdc-menu-surface" tabindex="-1">\n                <ul class="mdc-list" role="menu" aria-hidden="true" aria-orientation="vertical">\n                    <li class="mdc-list-item" role="menuitem">\n                        <span class="mdc-list-item__text">Overall</span>\n                    </li>\n                    ',"\n                </ul>\n            </div>\n        </div>\n        "],['\n        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">\n        <link rel="stylesheet" href="/dist/site.css">\n\n        <div id="menu" class="mdc-menu-surface--anchor">\n            <button class="mdc-icon-button material-icons" @click="','">arrow_drop_down</button>\n            <div class="mdc-menu mdc-menu-surface" tabindex="-1">\n                <ul class="mdc-list" role="menu" aria-hidden="true" aria-orientation="vertical">\n                    <li class="mdc-list-item" role="menuitem">\n                        <span class="mdc-list-item__text">Overall</span>\n                    </li>\n                    ',"\n                </ul>\n            </div>\n        </div>\n        "]),a=w(['\n                    <li class="mdc-list-item" role="menuitem" data-award-id=','>\n                        <span class="mdc-list-item__text">',"</span>\n                    </li>\n                    "],['\n                    <li class="mdc-list-item" role="menuitem" data-award-id=','>\n                        <span class="mdc-list-item__text">',"</span>\n                    </li>\n                    "]),s=n(144),c=n(378),u=n(145),l=n(146),d=n(379),f=n(394),p=n(387),m=n(102),h=n(395),y=(r=h)&&r.__esModule?r:{default:r};function w(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}l.store.addReducers({awards:y.default});var b=function(e){function t(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,t),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,(0,u.connect)(l.store)(c.PageViewElement)),i(t,[{key:"render",value:function(){var e=this;return(0,s.html)(o,function(){return e.clickHandler()},this._awards&&(0,d.repeat)(this._awards,function(e){return(0,s.html)(a,e.id,e.title)}))}},{key:"firstUpdated",value:function(){var e=this.shadowRoot.querySelector(".mdc-menu");this._menu=new f.MDCMenu(e),e.addEventListener("MDCMenu:selected",this.menuSelected)}},{key:"clickHandler",value:function(){this._menu.open=!this._menu.open}},{key:"stateChanged",value:function(e){this._awards=Object.values(e.awards.awards)}},{key:"menuSelected",value:function(e){var t=e.detail;t.index>0?l.store.dispatch((0,m.applyFilter)(t.item.dataset.awardId)):l.store.dispatch((0,m.applyFilter)(""))}}],[{key:"properties",get:function(){return{_menu:{type:Object},_awards:{type:Array}}}}]),t}();window.customElements.define("results-menu",b),t.getCompetitionAwards=p.getCompetitionAwards},378:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.PageViewElement=void 0;var r=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),i=n(144);t.PageViewElement=function(e){function t(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,t),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,i.LitElement),r(t,[{key:"shouldUpdate",value:function(){return this.active}}],[{key:"properties",get:function(){return{active:{type:Boolean}}}}]),t}()},387:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_AWARDS="RECEIVE_AWARDS",i=(t.getCompetitionAwards=function(e){return function(t){fetch("/api/competitions/"+e+"/awards").then(function(e){return e.json()}).then(function(e){return t(i(e))})}},function(e){return{type:r,awards:e}})},395:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},i=n(387),o={awards:{},awardsForCompetition:{}};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:o,t=arguments[1];switch(t.type){case i.RECEIVE_AWARDS:return r({},e,{awards:t.awards});default:return e}}}}]);