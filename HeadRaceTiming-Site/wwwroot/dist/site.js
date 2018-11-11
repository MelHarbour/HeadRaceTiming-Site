!function(t){var e={};function i(s){if(e[s])return e[s].exports;var a=e[s]={i:s,l:!1,exports:{}};return t[s].call(a.exports,a,a.exports,i),a.l=!0,a.exports}i.m=t,i.c=e,i.d=function(t,e,s){i.o(t,e)||Object.defineProperty(t,e,{enumerable:!0,get:s})},i.r=function(t){"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},i.t=function(t,e){if(1&e&&(t=i(t)),8&e)return t;if(4&e&&"object"==typeof t&&t&&t.__esModule)return t;var s=Object.create(null);if(i.r(s),Object.defineProperty(s,"default",{enumerable:!0,value:t}),2&e&&"string"!=typeof t)for(var a in t)i.d(s,a,function(e){return t[e]}.bind(null,a));return s},i.n=function(t){var e=t&&t.__esModule?function(){return t.default}:function(){return t};return i.d(e,"a",e),e},i.o=function(t,e){return Object.prototype.hasOwnProperty.call(t,e)},i.p="",i(i.s=0)}([function(t,e,i){i(2),t.exports=i(1)},function(t,e,i){t.exports=i.p+"site.css"},function(t,e,i){"use strict";i.r(e);var s=
/**
 * @license
 * Copyright 2016 Google Inc.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
class{static get cssClasses(){return{}}static get strings(){return{}}static get numbers(){return{}}static get defaultAdapter(){return{}}constructor(t={}){this.adapter_=t}init(){}destroy(){}};
/**
 * @license
 * Copyright 2016 Google Inc.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */class a{static attachTo(t){return new a(t,new s)}constructor(t,e,...i){this.root_=t,this.initialize(...i),this.foundation_=void 0===e?this.getDefaultFoundation():e,this.foundation_.init(),this.initialSyncWithDOM()}initialize(){}getDefaultFoundation(){throw new Error("Subclasses must override getDefaultFoundation to return a properly configured foundation class")}initialSyncWithDOM(){}destroy(){this.foundation_.destroy()}listen(t,e){this.root_.addEventListener(t,e)}unlisten(t,e){this.root_.removeEventListener(t,e)}emit(t,e,i=!1){let s;"function"==typeof CustomEvent?s=new CustomEvent(t,{detail:e,bubbles:i}):(s=document.createEvent("CustomEvent")).initCustomEvent(t,i,!1,e),this.root_.dispatchEvent(s)}}var r=a;
/**
 * @license
 * Copyright 2016 Google Inc.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
/**
 * @license
 * Copyright 2016 Google Inc.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
const n={ROOT:"mdc-ripple-upgraded",UNBOUNDED:"mdc-ripple-upgraded--unbounded",BG_FOCUSED:"mdc-ripple-upgraded--background-focused",FG_ACTIVATION:"mdc-ripple-upgraded--foreground-activation",FG_DEACTIVATION:"mdc-ripple-upgraded--foreground-deactivation"},o={VAR_LEFT:"--mdc-ripple-left",VAR_TOP:"--mdc-ripple-top",VAR_FG_SIZE:"--mdc-ripple-fg-size",VAR_FG_SCALE:"--mdc-ripple-fg-scale",VAR_FG_TRANSLATE_START:"--mdc-ripple-fg-translate-start",VAR_FG_TRANSLATE_END:"--mdc-ripple-fg-translate-end"},d={PADDING:10,INITIAL_ORIGIN_SCALE:.6,DEACTIVATION_TIMEOUT_MS:225,FG_DEACTIVATION_MS:150,TAP_DELAY_MS:300};
/**
 * @license
 * Copyright 2016 Google Inc.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
let l,c;function _(t=window,e=!1){if(void 0===c||e){let e=!1;try{t.document.addEventListener("test",null,{get passive(){return e=!0}})}catch(t){}c=e}return!!c&&{passive:!0}}const h=["touchstart","pointerdown","mousedown","keydown"],p=["touchend","pointerup","mouseup","contextmenu"];let u=[];class v extends s{static get cssClasses(){return n}static get strings(){return o}static get numbers(){return d}static get defaultAdapter(){return{browserSupportsCssVars:()=>{},isUnbounded:()=>{},isSurfaceActive:()=>{},isSurfaceDisabled:()=>{},addClass:()=>{},removeClass:()=>{},containsEventTarget:()=>{},registerInteractionHandler:()=>{},deregisterInteractionHandler:()=>{},registerDocumentInteractionHandler:()=>{},deregisterDocumentInteractionHandler:()=>{},registerResizeHandler:()=>{},deregisterResizeHandler:()=>{},updateCssVariable:()=>{},computeBoundingRect:()=>{},getWindowPageOffset:()=>{}}}constructor(t){super(Object.assign(v.defaultAdapter,t)),this.layoutFrame_=0,this.frame_={width:0,height:0},this.activationState_=this.defaultActivationState_(),this.initialSize_=0,this.maxRadius_=0,this.activateHandler_=(t=>this.activate_(t)),this.deactivateHandler_=(()=>this.deactivate_()),this.focusHandler_=(()=>this.handleFocus()),this.blurHandler_=(()=>this.handleBlur()),this.resizeHandler_=(()=>this.layout()),this.unboundedCoords_={left:0,top:0},this.fgScale_=0,this.activationTimer_=0,this.fgDeactivationRemovalTimer_=0,this.activationAnimationHasEnded_=!1,this.activationTimerCallback_=(()=>{this.activationAnimationHasEnded_=!0,this.runDeactivationUXLogicIfReady_()}),this.previousActivationEvent_}supportsPressRipple_(){return this.adapter_.browserSupportsCssVars()}defaultActivationState_(){return{isActivated:!1,hasDeactivationUXRun:!1,wasActivatedByPointer:!1,wasElementMadeActive:!1,activationEvent:void 0,isProgrammatic:!1}}init(){const t=this.supportsPressRipple_();if(this.registerRootHandlers_(t),t){const{ROOT:t,UNBOUNDED:e}=v.cssClasses;requestAnimationFrame(()=>{this.adapter_.addClass(t),this.adapter_.isUnbounded()&&(this.adapter_.addClass(e),this.layoutInternal_())})}}destroy(){if(this.supportsPressRipple_()){this.activationTimer_&&(clearTimeout(this.activationTimer_),this.activationTimer_=0,this.adapter_.removeClass(v.cssClasses.FG_ACTIVATION)),this.fgDeactivationRemovalTimer_&&(clearTimeout(this.fgDeactivationRemovalTimer_),this.fgDeactivationRemovalTimer_=0,this.adapter_.removeClass(v.cssClasses.FG_DEACTIVATION));const{ROOT:t,UNBOUNDED:e}=v.cssClasses;requestAnimationFrame(()=>{this.adapter_.removeClass(t),this.adapter_.removeClass(e),this.removeCssVars_()})}this.deregisterRootHandlers_(),this.deregisterDeactivationHandlers_()}registerRootHandlers_(t){t&&(h.forEach(t=>{this.adapter_.registerInteractionHandler(t,this.activateHandler_)}),this.adapter_.isUnbounded()&&this.adapter_.registerResizeHandler(this.resizeHandler_)),this.adapter_.registerInteractionHandler("focus",this.focusHandler_),this.adapter_.registerInteractionHandler("blur",this.blurHandler_)}registerDeactivationHandlers_(t){"keydown"===t.type?this.adapter_.registerInteractionHandler("keyup",this.deactivateHandler_):p.forEach(t=>{this.adapter_.registerDocumentInteractionHandler(t,this.deactivateHandler_)})}deregisterRootHandlers_(){h.forEach(t=>{this.adapter_.deregisterInteractionHandler(t,this.activateHandler_)}),this.adapter_.deregisterInteractionHandler("focus",this.focusHandler_),this.adapter_.deregisterInteractionHandler("blur",this.blurHandler_),this.adapter_.isUnbounded()&&this.adapter_.deregisterResizeHandler(this.resizeHandler_)}deregisterDeactivationHandlers_(){this.adapter_.deregisterInteractionHandler("keyup",this.deactivateHandler_),p.forEach(t=>{this.adapter_.deregisterDocumentInteractionHandler(t,this.deactivateHandler_)})}removeCssVars_(){const{strings:t}=v;Object.keys(t).forEach(e=>{0===e.indexOf("VAR_")&&this.adapter_.updateCssVariable(t[e],null)})}activate_(t){if(this.adapter_.isSurfaceDisabled())return;const e=this.activationState_;if(e.isActivated)return;const i=this.previousActivationEvent_;i&&void 0!==t&&i.type!==t.type||(e.isActivated=!0,e.isProgrammatic=void 0===t,e.activationEvent=t,e.wasActivatedByPointer=!e.isProgrammatic&&(void 0!==t&&("mousedown"===t.type||"touchstart"===t.type||"pointerdown"===t.type)),void 0!==t&&u.length>0&&u.some(t=>this.adapter_.containsEventTarget(t))?this.resetActivationState_():(void 0!==t&&(u.push(t.target),this.registerDeactivationHandlers_(t)),e.wasElementMadeActive=this.checkElementMadeActive_(t),e.wasElementMadeActive&&this.animateActivation_(),requestAnimationFrame(()=>{u=[],e.wasElementMadeActive||void 0===t||" "!==t.key&&32!==t.keyCode||(e.wasElementMadeActive=this.checkElementMadeActive_(t),e.wasElementMadeActive&&this.animateActivation_()),e.wasElementMadeActive||(this.activationState_=this.defaultActivationState_())})))}checkElementMadeActive_(t){return void 0===t||"keydown"!==t.type||this.adapter_.isSurfaceActive()}activate(t){this.activate_(t)}animateActivation_(){const{VAR_FG_TRANSLATE_START:t,VAR_FG_TRANSLATE_END:e}=v.strings,{FG_DEACTIVATION:i,FG_ACTIVATION:s}=v.cssClasses,{DEACTIVATION_TIMEOUT_MS:a}=v.numbers;this.layoutInternal_();let r="",n="";if(!this.adapter_.isUnbounded()){const{startPoint:t,endPoint:e}=this.getFgTranslationCoordinates_();r=`${t.x}px, ${t.y}px`,n=`${e.x}px, ${e.y}px`}this.adapter_.updateCssVariable(t,r),this.adapter_.updateCssVariable(e,n),clearTimeout(this.activationTimer_),clearTimeout(this.fgDeactivationRemovalTimer_),this.rmBoundedActivationClasses_(),this.adapter_.removeClass(i),this.adapter_.computeBoundingRect(),this.adapter_.addClass(s),this.activationTimer_=setTimeout(()=>this.activationTimerCallback_(),a)}getFgTranslationCoordinates_(){const{activationEvent:t,wasActivatedByPointer:e}=this.activationState_;let i;return{startPoint:i={x:(i=e?function(t,e,i){const{x:s,y:a}=e,r=s+i.left,n=a+i.top;let o,d;return"touchstart"===t.type?(o=(t=t).changedTouches[0].pageX-r,d=t.changedTouches[0].pageY-n):(o=(t=t).pageX-r,d=t.pageY-n),{x:o,y:d}}
/**
 * @license
 * Copyright 2016 Google Inc.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */(t,this.adapter_.getWindowPageOffset(),this.adapter_.computeBoundingRect()):{x:this.frame_.width/2,y:this.frame_.height/2}).x-this.initialSize_/2,y:i.y-this.initialSize_/2},endPoint:{x:this.frame_.width/2-this.initialSize_/2,y:this.frame_.height/2-this.initialSize_/2}}}runDeactivationUXLogicIfReady_(){const{FG_DEACTIVATION:t}=v.cssClasses,{hasDeactivationUXRun:e,isActivated:i}=this.activationState_;(e||!i)&&this.activationAnimationHasEnded_&&(this.rmBoundedActivationClasses_(),this.adapter_.addClass(t),this.fgDeactivationRemovalTimer_=setTimeout(()=>{this.adapter_.removeClass(t)},d.FG_DEACTIVATION_MS))}rmBoundedActivationClasses_(){const{FG_ACTIVATION:t}=v.cssClasses;this.adapter_.removeClass(t),this.activationAnimationHasEnded_=!1,this.adapter_.computeBoundingRect()}resetActivationState_(){this.previousActivationEvent_=this.activationState_.activationEvent,this.activationState_=this.defaultActivationState_(),setTimeout(()=>this.previousActivationEvent_=void 0,v.numbers.TAP_DELAY_MS)}deactivate_(){const t=this.activationState_;if(!t.isActivated)return;const e=Object.assign({},t);t.isProgrammatic?(requestAnimationFrame(()=>this.animateDeactivation_(e)),this.resetActivationState_()):(this.deregisterDeactivationHandlers_(),requestAnimationFrame(()=>{this.activationState_.hasDeactivationUXRun=!0,this.animateDeactivation_(e),this.resetActivationState_()}))}deactivate(){this.deactivate_()}animateDeactivation_({wasActivatedByPointer:t,wasElementMadeActive:e}){(t||e)&&this.runDeactivationUXLogicIfReady_()}layout(){this.layoutFrame_&&cancelAnimationFrame(this.layoutFrame_),this.layoutFrame_=requestAnimationFrame(()=>{this.layoutInternal_(),this.layoutFrame_=0})}layoutInternal_(){this.frame_=this.adapter_.computeBoundingRect();const t=Math.max(this.frame_.height,this.frame_.width);this.maxRadius_=this.adapter_.isUnbounded()?t:(()=>{return Math.sqrt(Math.pow(this.frame_.width,2)+Math.pow(this.frame_.height,2))+v.numbers.PADDING})(),this.initialSize_=Math.floor(t*v.numbers.INITIAL_ORIGIN_SCALE),this.fgScale_=this.maxRadius_/this.initialSize_,this.updateLayoutCssVars_()}updateLayoutCssVars_(){const{VAR_FG_SIZE:t,VAR_LEFT:e,VAR_TOP:i,VAR_FG_SCALE:s}=v.strings;this.adapter_.updateCssVariable(t,`${this.initialSize_}px`),this.adapter_.updateCssVariable(s,this.fgScale_),this.adapter_.isUnbounded()&&(this.unboundedCoords_={left:Math.round(this.frame_.width/2-this.initialSize_/2),top:Math.round(this.frame_.height/2-this.initialSize_/2)},this.adapter_.updateCssVariable(e,`${this.unboundedCoords_.left}px`),this.adapter_.updateCssVariable(i,`${this.unboundedCoords_.top}px`))}setUnbounded(t){const{UNBOUNDED:e}=v.cssClasses;t?this.adapter_.addClass(e):this.adapter_.removeClass(e)}handleFocus(){requestAnimationFrame(()=>this.adapter_.addClass(v.cssClasses.BG_FOCUSED))}handleBlur(){requestAnimationFrame(()=>this.adapter_.removeClass(v.cssClasses.BG_FOCUSED))}}var g=v;
/**
 * @license
 * Copyright 2016 Google Inc.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */class m extends r{constructor(...t){super(...t),this.disabled=!1,this.unbounded_}static attachTo(t,{isUnbounded:e}={}){const i=new m(t);return void 0!==e&&(i.unbounded=e),i}static createAdapter(t){const e=function(t){const e=["matches","webkitMatchesSelector","msMatchesSelector"];let i="matches";for(let s=0;s<e.length;s++){const a=e[s];if(a in t){i=a;break}}return i}(HTMLElement.prototype);return{browserSupportsCssVars:()=>(function(t,e=!1){let i=l;if("boolean"==typeof l&&!e)return i;if(!t.CSS||"function"!=typeof t.CSS.supports)return;const s=t.CSS.supports("--css-vars","yes"),a=t.CSS.supports("(--css-vars: yes)")&&t.CSS.supports("color","#00000000");return i=!(!s&&!a||function(t){const e=t.document,i=e.createElement("div");i.className="mdc-ripple-surface--test-edge-var-bug",e.body.appendChild(i);const s=t.getComputedStyle(i),a=null!==s&&"solid"===s.borderTopStyle;return i.remove(),a}(t)),e||(l=i),i})(window),isUnbounded:()=>t.unbounded,isSurfaceActive:()=>t.root_[e](":active"),isSurfaceDisabled:()=>t.disabled,addClass:e=>t.root_.classList.add(e),removeClass:e=>t.root_.classList.remove(e),containsEventTarget:e=>t.root_.contains(e),registerInteractionHandler:(e,i)=>t.root_.addEventListener(e,i,_()),deregisterInteractionHandler:(e,i)=>t.root_.removeEventListener(e,i,_()),registerDocumentInteractionHandler:(t,e)=>document.documentElement.addEventListener(t,e,_()),deregisterDocumentInteractionHandler:(t,e)=>document.documentElement.removeEventListener(t,e,_()),registerResizeHandler:t=>window.addEventListener("resize",t),deregisterResizeHandler:t=>window.removeEventListener("resize",t),updateCssVariable:(e,i)=>t.root_.style.setProperty(e,i),computeBoundingRect:()=>t.root_.getBoundingClientRect(),getWindowPageOffset:()=>({x:window.pageXOffset,y:window.pageYOffset})}}get unbounded(){return this.unbounded_}set unbounded(t){this.unbounded_=Boolean(t),this.setUnbounded_()}setUnbounded_(){this.foundation_.setUnbounded(this.unbounded_)}activate(){this.foundation_.activate()}deactivate(){this.foundation_.deactivate()}layout(){this.foundation_.layout()}getDefaultFoundation(){return new g(m.createAdapter(this))}initialSyncWithDOM(){this.unbounded="mdcRippleIsUnbounded"in this.root_.dataset}}class A{}A.prototype.root_,A.prototype.unbounded,A.prototype.disabled;
/**
 * @license
 * Copyright 2018 Google Inc.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
const S={FIXED_CLASS:"mdc-top-app-bar--fixed",FIXED_SCROLLED_CLASS:"mdc-top-app-bar--fixed-scrolled",SHORT_CLASS:"mdc-top-app-bar--short",SHORT_HAS_ACTION_ITEM_CLASS:"mdc-top-app-bar--short-has-action-item",SHORT_COLLAPSED_CLASS:"mdc-top-app-bar--short-collapsed"},f={DEBOUNCE_THROTTLE_RESIZE_TIME_MS:100,MAX_TOP_APP_BAR_HEIGHT:128},T={ACTION_ITEM_SELECTOR:".mdc-top-app-bar__action-item",NAVIGATION_EVENT:"MDCTopAppBar:nav",NAVIGATION_ICON_SELECTOR:".mdc-top-app-bar__navigation-icon",ROOT_SELECTOR:".mdc-top-app-bar",TITLE_SELECTOR:".mdc-top-app-bar__title"};
/**
 * @license
 * Copyright 2018 Google Inc.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
class C extends s{static get strings(){return T}static get cssClasses(){return S}static get numbers(){return f}static get defaultAdapter(){return{hasClass:()=>{},addClass:()=>{},removeClass:()=>{},setStyle:()=>{},getTopAppBarHeight:()=>{},registerNavigationIconInteractionHandler:()=>{},deregisterNavigationIconInteractionHandler:()=>{},notifyNavigationIconClicked:()=>{},registerScrollHandler:()=>{},deregisterScrollHandler:()=>{},registerResizeHandler:()=>{},deregisterResizeHandler:()=>{},getViewportScrollY:()=>0,getTotalActionItems:()=>0}}constructor(t){super(Object.assign(C.defaultAdapter,t)),this.navClickHandler_=(()=>this.adapter_.notifyNavigationIconClicked()),this.scrollHandler_=(()=>{})}init(){this.adapter_.registerNavigationIconInteractionHandler("click",this.navClickHandler_)}destroy(){this.adapter_.deregisterNavigationIconInteractionHandler("click",this.navClickHandler_)}initScrollHandler(){this.adapter_.registerScrollHandler(this.scrollHandler_)}destroyScrollHandler(){this.adapter_.deregisterScrollHandler(this.scrollHandler_)}}var E=C;
/**
 * @license
 * Copyright 2018 Google Inc.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */var H=class extends E{constructor(t){super(t),this.wasScrolled_=!1,this.scrollHandler_=(()=>this.fixedScrollHandler_())}init(){super.init(),this.adapter_.registerScrollHandler(this.scrollHandler_)}destroy(){super.destroy(),this.adapter_.deregisterScrollHandler(this.scrollHandler_)}fixedScrollHandler_(){this.adapter_.getViewportScrollY()<=0?this.wasScrolled_&&(this.adapter_.removeClass(S.FIXED_SCROLLED_CLASS),this.wasScrolled_=!1):this.wasScrolled_||(this.adapter_.addClass(S.FIXED_SCROLLED_CLASS),this.wasScrolled_=!0)}};
/**
 * @license
 * Copyright 2018 Google Inc.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */var I=class extends E{constructor(t){super(t),this.isCollapsed=!1,this.scrollHandler_=(()=>this.shortAppBarScrollHandler_())}init(){super.init();const t=this.adapter_.hasClass(S.SHORT_COLLAPSED_CLASS);this.adapter_.getTotalActionItems()>0&&this.adapter_.addClass(S.SHORT_HAS_ACTION_ITEM_CLASS),t||(this.adapter_.registerScrollHandler(this.scrollHandler_),this.shortAppBarScrollHandler_())}destroy(){super.destroy(),this.adapter_.deregisterScrollHandler(this.scrollHandler_)}shortAppBarScrollHandler_(){this.adapter_.getViewportScrollY()<=0?this.isCollapsed&&(this.adapter_.removeClass(S.SHORT_COLLAPSED_CLASS),this.isCollapsed=!1):this.isCollapsed||(this.adapter_.addClass(S.SHORT_COLLAPSED_CLASS),this.isCollapsed=!0)}};
/**
 * @license
 * Copyright 2018 Google Inc.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */const y=0;var b=class extends E{constructor(t){super(t),this.lastScrollPosition_=this.adapter_.getViewportScrollY(),this.topAppBarHeight_=this.adapter_.getTopAppBarHeight(),this.wasDocked_=!0,this.isDockedShowing_=!0,this.currentAppBarOffsetTop_=0,this.isCurrentlyBeingResized_=!1,this.resizeThrottleId_=y,this.resizeDebounceId_=y,this.scrollHandler_=(()=>this.topAppBarScrollHandler_()),this.resizeHandler_=(()=>this.topAppBarResizeHandler_())}init(){super.init(),this.adapter_.registerScrollHandler(this.scrollHandler_),this.adapter_.registerResizeHandler(this.resizeHandler_)}destroy(){super.destroy(),this.adapter_.deregisterScrollHandler(this.scrollHandler_),this.adapter_.deregisterResizeHandler(this.resizeHandler_),this.adapter_.setStyle("top","")}checkForUpdate_(){const t=-this.topAppBarHeight_,e=this.currentAppBarOffsetTop_<0,i=this.currentAppBarOffsetTop_>t,s=e&&i;if(s)this.wasDocked_=!1;else{if(!this.wasDocked_)return this.wasDocked_=!0,!0;if(this.isDockedShowing_!==i)return this.isDockedShowing_=i,!0}return s}moveTopAppBar_(){if(this.checkForUpdate_()){let t=this.currentAppBarOffsetTop_;Math.abs(t)>=this.topAppBarHeight_&&(t=-f.MAX_TOP_APP_BAR_HEIGHT),this.adapter_.setStyle("top",t+"px")}}topAppBarScrollHandler_(){const t=Math.max(this.adapter_.getViewportScrollY(),0),e=t-this.lastScrollPosition_;this.lastScrollPosition_=t,this.isCurrentlyBeingResized_||(this.currentAppBarOffsetTop_-=e,this.currentAppBarOffsetTop_>0?this.currentAppBarOffsetTop_=0:Math.abs(this.currentAppBarOffsetTop_)>this.topAppBarHeight_&&(this.currentAppBarOffsetTop_=-this.topAppBarHeight_),this.moveTopAppBar_())}topAppBarResizeHandler_(){this.resizeThrottleId_||(this.resizeThrottleId_=setTimeout(()=>{this.resizeThrottleId_=y,this.throttledResizeHandler_()},f.DEBOUNCE_THROTTLE_RESIZE_TIME_MS)),this.isCurrentlyBeingResized_=!0,this.resizeDebounceId_&&clearTimeout(this.resizeDebounceId_),this.resizeDebounceId_=setTimeout(()=>{this.topAppBarScrollHandler_(),this.isCurrentlyBeingResized_=!1,this.resizeDebounceId_=y},f.DEBOUNCE_THROTTLE_RESIZE_TIME_MS)}throttledResizeHandler_(){const t=this.adapter_.getTopAppBarHeight();this.topAppBarHeight_!==t&&(this.wasDocked_=!1,this.currentAppBarOffsetTop_-=this.topAppBarHeight_-t,this.topAppBarHeight_=t),this.topAppBarScrollHandler_()}};
/**
 * @license
 * Copyright 2018 Google Inc.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */class O extends r{constructor(...t){super(...t),this.navIcon_,this.iconRipples_,this.scrollTarget_}initialize(t=(t=>m.attachTo(t))){this.navIcon_=this.root_.querySelector(T.NAVIGATION_ICON_SELECTOR);const e=[].slice.call(this.root_.querySelectorAll(T.ACTION_ITEM_SELECTOR));this.navIcon_&&e.push(this.navIcon_),this.iconRipples_=e.map(e=>{const i=t(e);return i.unbounded=!0,i})}destroy(){this.iconRipples_.forEach(t=>t.destroy()),super.destroy()}setScrollTarget(t){this.foundation_.destroyScrollHandler(),this.scrollTarget_=t,this.foundation_.initScrollHandler()}static attachTo(t){return new O(t)}getDefaultFoundation(){const t=Object.assign({hasClass:t=>this.root_.classList.contains(t),addClass:t=>this.root_.classList.add(t),removeClass:t=>this.root_.classList.remove(t),setStyle:(t,e)=>this.root_.style.setProperty(t,e),getTopAppBarHeight:()=>this.root_.clientHeight,registerNavigationIconInteractionHandler:(t,e)=>{this.navIcon_&&this.navIcon_.addEventListener(t,e)},deregisterNavigationIconInteractionHandler:(t,e)=>{this.navIcon_&&this.navIcon_.removeEventListener(t,e)},notifyNavigationIconClicked:()=>{this.emit(T.NAVIGATION_EVENT,{})},registerScrollHandler:t=>this.scrollTarget_.addEventListener("scroll",t),deregisterScrollHandler:t=>this.scrollTarget_.removeEventListener("scroll",t),registerResizeHandler:t=>window.addEventListener("resize",t),deregisterResizeHandler:t=>window.removeEventListener("resize",t),getViewportScrollY:()=>this.scrollTarget_[this.scrollTarget_===window?"pageYOffset":"scrollTop"],getTotalActionItems:()=>this.root_.querySelectorAll(T.ACTION_ITEM_SELECTOR).length});let e;return this.scrollTarget_=window,e=this.root_.classList.contains(S.SHORT_CLASS)?new I(t):this.root_.classList.contains(S.FIXED_CLASS)?new H(t):new b(t)}}const R=document.querySelector(".mdc-top-app-bar");new O(R)}]);