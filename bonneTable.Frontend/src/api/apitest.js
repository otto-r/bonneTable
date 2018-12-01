import axios from "axios";

export function getAll() {
  axios
    .get("https://localhost:44383/api/booking/getall")
    .then(function(response) {
      console.log(response.data);
    })
    .catch(function(error) {
      console.log(error);
    });
    return response.data
}
