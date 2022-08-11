


$(document).ready(function () {
    getKendaraan();
});


let num = 1;
const rowData = (item) => {
    return `
        <tr>
            <td>${num}</td>
            <td>${item.noRegistrasi}</td>
            <td>${item.namaPemilik}</td>
            <td>${item.merk}</td>
            <td>${item.tahunPembuatan}</td>
            <td>${item.kapasitas} CC</td>
            <td>${item.warna}</td>
            <td>${item.bahanBakar}</td>
            <td>
                <form method="POST" class="d-flex justify-content-center" style="gap: 1rem">
                    <a class="text-warning" href="/Kendaraan/Detail?id=${item.noRegistrasi}" id="detail" onClick="detailKendaraan('${item.noRegistrasi}')">Detail</a>
                    <a class="text-primary" href="/Kendaraan/Edit?id=${item.noRegistrasi}" onClick="detailKendaraan('${item.noRegistrasi}')">Edit</a>
                    <button type="button" name="idDelete" class="text-danger border-0" style="background: transparent;" onClick="deleteKendaraan('${item.noRegistrasi}')">Delete</a>
                </div>
            </td>
        </tr>
    `
};

const getKendaraan = () => {
    $.ajax({
        method: "GET",
        url: "/api/kendaraan/getkendaraan",
        success: function (data) {
            const rowContainer = $('#row-data');
            rowContainer.html('');

            data.forEach(item => {
                console.log(item)
                rowContainer.append(rowData(item));
                num++;
            })
        },
        error(err) {
            alert(err, Error);
        }
    })
}

$("#btn-search").click(function () {
    var noReg = $("#input-noreg").val();
    var nama = $("#input-nama").val();
    $.ajax({
        method: "GET",
        url: "/api/kendaraan/searchkendaraan",
        data: {
            noRegistrasi: noReg,
            namaPemilik: nama
        },
        success: function (res) {
            $("#input-noreg").val('');
            $("#input-nama").val('');
            const rowContainer = $("#row-data");
            rowContainer.html('');
            num = 1;
            res.forEach(item => {
                console.log(item);
                rowContainer.append(rowData(item));
                num++;
            })
        },
        error: function (err) {
            console.log(err);
        }
    })

});

const detailKendaraan = (id) => {
    console.log(id);

    $.ajax({
        method: "GET",
        url: `/api/kendaraan/detailkendaraan/${id}`,
        data: {
            noRegistrasi: id
        },
        success: function (res) {
            $("#no-reg").val(res.noRegistrasi);
            $("#tahun-pembuatan").val(res.tahunPembuatan);
            $("#nama-pemilik").val(res.namaPemilik);
            $("#kapasitas").val(res.kapasitas);
            $("#merk-kendaraan").val(res.merk);
            $("#warna").val(res.warna);
            $("#alamat").val(res.alamat);
            $("#bahan-bakar").val(res.bahanBakar);
        },
        error: function (err) {
            alert("Error Server");
        }
    })
};

const deleteKendaraan = (id) => {

    const resConfirm = confirm(`Anda yakin ingin menghapus ${id}`);

    if (!resConfirm) return;

    $.ajax({
        method: "DELETE",
        url: `/api/kendaraan/deletekendaraan/${id}`,
        
        success: (respon) => {
            alert(`Data ${respon.noRegistrasi} Berhasil diHapus`);
            getKendaraan();
        },
        error: (err) => {
            console.log(err);
            alert(err);
        }
    })
};