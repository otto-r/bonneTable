import axios from "axios";

let baseUrl = "https://localhost:44383/api/table/";

export async function getTables() {
  try {
    const response = await axios({
      method: "get",
      url: baseUrl
    });
    console.log(response.data)
    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function getById(id) {
  try {
    const response = await axios({
      method: "get",
      url: baseUrl + "?id=" + id
    });
    console.log(response.data)
    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function removeTable(id) {
  try {
    const response = await axios({
      method: "delete",
      url: baseUrl,
      data: id
    });
    console.log(response.data)
    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function addTable(seats) {
  try {
    const response = await axios({
      method: "post",
      url: baseUrl,
      data: seats
    });
    console.log(response.data)
    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function editTable(seats) {
  try {
    const response = await axios({
      method: "put",
      url: baseUrl,
      data: seats
    });
    console.log(response.data)
    return response.data;
  } catch (error) {
    console.log(error);
  }
}
