import axios from "axios";

let baseUrl = "https://localhost:44383/api/booking/";

export async function getAll() {
  try {
    const response = await axios({
      method: "get",
      url: baseUrl + "getall",
      headers: {
        Authorization: "Bearer " + localStorage.token
      }
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
      url: baseUrl + "getbydate/" + dateTime
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
      url: baseUrl + "getbyemail/" + email,
      headers: {
        Authorization: "Bearer " + localStorage.token
      }
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

export async function adminBook(request) {
  try {
    const response = await axios({
      method: "post",
      url: baseUrl + "adminbook/",
      data: request,
      headers: {
        Authorization: "Bearer " + localStorage.token
      }
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
      url: baseUrl + id,
      headers: {
        Authorization: "Bearer " + localStorage.token
      }
    });
    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function edit(booking) {
  try {
    const response = await axios({
      method: "put",
      url: baseUrl + booking.id,
      data: booking,
      headers: {
        Authorization: "Bearer " + localStorage.token
      }
    });
    return response.data;
  } catch (error) {
    console.log(error);
  }
}
