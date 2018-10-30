export function jsonParse(json) {
    const $divCard = $("<div>").addClass("card").insertBefore("#plz");
    const $divCardBody = $("<div>").addClass("card-body").attr("id", `${json.objectID}`).appendTo($divCard);
    const $cardTitle = $("<h5>").text(json.title).appendTo($divCardBody);
    const $cardLink = $("<a>").addClass("card-link").attr("href", json.url).text(json.url).appendTo($divCardBody);
    const $button = $("<button>").click((e) => { window.location.replace("https://localhost:5001/savedarticles/Create"); }).text("plz").appendTo($divCardBody)
}