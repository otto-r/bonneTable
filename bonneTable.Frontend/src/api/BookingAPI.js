import axios from "axios";

let baseUrl = "https://localhost:44383/api/booking/";

export async function getAll() {
  try {
    const response = await axios({
      method: "get",
      url: baseUrl + "getall"
    });
    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function getByDate(dateTime) {
  try {
    const response = await axios({
      method: "get",
      url: baseUrl + "?dateTime=" + dateTime
    });
    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function getByEmail(email) {
  try {
    const response = await axios({
      method: "get",
      url: baseUrl + "/getbyemail/" + "?email=" + email
    });
    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function book(request) {
  try {
    const response = await axios({
      method: "post",
      url: baseUrl,
      data: request
    });
    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function cancel(id) {
  try {
    const response = await axios({
      method: "delete",
      url: baseUrl + id
    });
    return response.data;
  } catch (error) {
    console.log(error);
  }
}
