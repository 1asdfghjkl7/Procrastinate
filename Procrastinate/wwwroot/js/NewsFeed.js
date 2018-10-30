import { jsonParse } from "./displayNewsFeed.js";

fetch('https://hn.algolia.com/api/v1/items/1')
    .then(function (response) {
        return response.json();
    })
    .then(response => { jsonParse(response) });

fetch('https://hn.algolia.com/api/v1/search?tags=front_page')
    .then(function (response) {
        return response.json();
    })
    .then(response => {
        response.hits.forEach(individualItem => jsonParse(individualItem))
        }
    );