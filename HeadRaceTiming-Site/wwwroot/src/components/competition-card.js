import { LitElement, html } from '@polymer/lit-element';

export class CompetitionCard extends connect(store)(LitElement) {
    render() {
        const item = this.item || {};
        return html`
        <div class="mdc-card competitionCard" style="background-color: #@item.BackgroundHtmlColor" data-competition-id="@item.FriendlyName">
            <div class="mdc-card__primary-action">
                @if (String.IsNullOrEmpty(item.ImageUriText))
                {
                    <div class="mdc-typography--headline6" style="color: #@item.TextHtmlColor">@item.Name</div>
                }
                else
                {
                    <div class="mdc-card__media" style="background-image: url('@item.ImageUriText')">
                        <div class="mdc-card__media-content mdc-typography--headline6" style="color: #@item.TextHtmlColor">@item.Name</div>
                    </div>
                }
            </div>
        </div>
        `;
    }

    static get properties() {
        return {
            item: {type: CompetitionState}
        }
    }
}

customElements.define('competition-card', CompetitionCard);