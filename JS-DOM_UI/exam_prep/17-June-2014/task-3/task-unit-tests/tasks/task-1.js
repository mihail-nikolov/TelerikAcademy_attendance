/* globals module */
function solve() {
  return function(selector){
    $(selector).html(`
    {{#each authors}}
    <div class="box {{#if this.right}}right{{/if}}">
      <div class="inner">
        <p><img alt="{{this.name}}" src={{this.image}} width="100" height="133"></p>
        <div>
          <h3>{{this.name}}</h3>
          {{#each this.titles}}
          <p>{{{this}}}</p>
          {{/each}} 
          <ul>
          {{#each this.urls}}
            <li><a href={{this}} target="_blank">{{this}}</a></li>
          {{/each}}
          </ul>
        </div>
      </div>
    </div>
  {{/each}}`);
  }
}

module.exports = solve;