(window.webpackJsonp=window.webpackJsonp||[]).push([[6],{409:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.getCompetitionAwards=void 0;var r=function(e,t,n){return t&&a(e.prototype,t),n&&a(e,n),e};function a(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}var i,o=_(['\n        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">\n        <link rel="stylesheet" href="/dist/site.css">\n\n        <div id="menu" class="mdc-menu-surface--anchor">\n            <button class="mdc-icon-button material-icons" @click="','">arrow_drop_down</button>\n            <div class="mdc-menu mdc-menu-surface" tabindex="-1">\n                <ul class="mdc-list" role="menu" aria-hidden="true" aria-orientation="vertical" tabindex="-1">\n                    <li class="mdc-list-item" role="menuitem">\n                        <span class="mdc-list-item__text">Overall</span>\n                    </li>\n                    ',"\n                </ul>\n            </div>\n        </div>\n        "],['\n        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">\n        <link rel="stylesheet" href="/dist/site.css">\n\n        <div id="menu" class="mdc-menu-surface--anchor">\n            <button class="mdc-icon-button material-icons" @click="','">arrow_drop_down</button>\n            <div class="mdc-menu mdc-menu-surface" tabindex="-1">\n                <ul class="mdc-list" role="menu" aria-hidden="true" aria-orientation="vertical" tabindex="-1">\n                    <li class="mdc-list-item" role="menuitem">\n                        <span class="mdc-list-item__text">Overall</span>\n                    </li>\n                    ',"\n                </ul>\n            </div>\n        </div>\n        "]),s=_(['\n                    <li class="mdc-list-item" role="menuitem" data-award-id=','>\n                        <span class="mdc-list-item__text">',"</span>\n                    </li>\n                    "],['\n                    <li class="mdc-list-item" role="menuitem" data-award-id=','>\n                        <span class="mdc-list-item__text">',"</span>\n                    </li>\n                    "]),c=n(166),u=n(415),l=n(167),d=n(168),f=n(414),p=n(437),m=n(416),w=n(426),h=(i=w)&&i.__esModule?i:{default:i},y=n(107);function _(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}d.store.addReducers({awards:h.default});var b=(function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(v,(0,l.connect)(d.store)(u.PageViewElement)),r(v,[{key:"render",value:function(){var e=this;return(0,c.html)(o,function(){return e.clickHandler()},this._awards&&(0,f.repeat)(this._awards,function(e){return(0,c.html)(s,e.id,e.title)}))}},{key:"firstUpdated",value:function(){var e=this.shadowRoot.querySelector(".mdc-menu");this._menu=new p.MDCMenu(e),e.addEventListener("MDCMenu:selected",this.menuSelected)}},{key:"clickHandler",value:function(){this._menu.open=!this._menu.open}},{key:"stateChanged",value:function(e){this._awards=(0,w.awardsListSelector)(e)}},{key:"menuSelected",value:function(e){var t=e.detail;0<t.index?d.store.dispatch((0,y.applyFilter)(t.item.dataset.awardId)):d.store.dispatch((0,y.applyFilter)(""))}}],[{key:"properties",get:function(){return{_menu:{type:Object},_awards:{type:Array}}}}]),v);function v(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,v),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(v.__proto__||Object.getPrototypeOf(v)).apply(this,arguments))}window.customElements.define("results-menu",b),t.getCompetitionAwards=m.getCompetitionAwards},415:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.PageViewElement=void 0;var r=function(e,t,n){return t&&a(e.prototype,t),n&&a(e,n),e};function a(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}var i=n(166);t.PageViewElement=(function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(o,i.LitElement),r(o,[{key:"shouldUpdate",value:function(){return this.active}}],[{key:"properties",get:function(){return{active:{type:Boolean}}}}]),o);function o(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,o),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(o.__proto__||Object.getPrototypeOf(o)).apply(this,arguments))}},416:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_AWARDS="RECEIVE_AWARDS",a=t.RECEIVE_CREW_AWARDS="RECEIVE_CREW_AWARDS",i=(t.getCompetitionAwards=function(e){return function(t){fetch("/api/competitions/"+e+"/awards").then(function(e){return e.json()}).then(function(e){return t(i(e))})}},t.getCrewAwards=function(n){return function(t){fetch("/api/crews/"+n+"/awards").then(function(e){return e.json()}).then(function(e){return t(o(e,n))})}},function(e){return{type:r,awards:e}}),o=function(e,t){return{type:a,awards:e,crewId:t}}},426:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.awardsListSelector=t.awardsSelector=void 0;var a=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},i=n(416),r=n(417),o={awards:{},orderedAwards:[]};t.default=function(e,t){var n=0<arguments.length&&void 0!==e?e:o,r=t;switch(r.type){case i.RECEIVE_AWARDS:return a({},n,{awards:r.awards.reduce(function(e,t){return e[t.id]=t,e},n.awards),orderedAwards:r.awards.map(function(e){return e.id})});case i.RECEIVE_CREW_AWARDS:return a({},n,{awards:r.awards.reduce(function(e,t){return e[t.id]=t,e},n.awards)});default:return n}};var s=t.awardsSelector=function(e){return e.awards&&e.awards.awards};t.awardsListSelector=(0,r.createSelector)(s,function(e){return e.awards&&e.awards.orderedAwards},function(t,e){if(t)return e.map(function(e){return t[e]})})}}]);