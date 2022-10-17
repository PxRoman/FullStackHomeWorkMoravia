export const apiGet = (url: string) => {
    return fetch("http://localhost:5000/api/" + url, {
        headers: new Headers({
            "Content-Type": "application/json",
            "Accept": "application/json",
        }),
        method: "GET"
    }).then(response => {
        return response.json();
    })
}

export const apiPut = (url: string, body: any) => {
    return fetch("http://localhost:5000/api/" + url, {
        headers: new Headers({
            "Content-Type": "application/json",
            "Accept": "application/json",
        }),
        method: "PUT",
        body: JSON.stringify(body)
    }).then(response => {
        return response;
    })
}