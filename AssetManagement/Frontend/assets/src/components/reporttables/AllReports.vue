<template>
<div class="pl-3 pr-3">
    <div class="mb-5 mb-lg-0 card">
        <div class="card-header">
            <div class="card-heading">List of all reports</div>
        </div>
        <div class="card-body">
            <div class="d-flex justify-content-between align-items-start align-items-sm-center mb-4 flex-column flex-sm-row">
                <div class="left d-flex align-items-center">
                    <div class="icon icon-lg shadow me-3 text-gray-700">
                        <i class="fa fa-list-alt"></i>
                    </div>
                    <div class="text">
                        <h6 class="mb-0 d-flex align-items-center">
                            <a href="/reportasset"><span>Assets Report</span></a>
                            <span class="dot dot-sm ms-2 bg-indigo"></span>
                        </h6>
                    </div>
                </div>
            </div>

            <div class="d-flex justify-content-between align-items-start align-items-sm-center mb-4 flex-column flex-sm-row">
                <div class="left d-flex align-items-center">
                    <div class="icon icon-lg shadow me-3 text-gray-700">
                        <i class="fa fa-address-card"></i>
                    </div>
                    <div class="text">
                        <h6 class="mb-0 d-flex align-items-center">
                            <a href="/reportassignedassets"><span>Assigned Assets Report</span></a>
                            <span class="dot dot-sm ms-2 bg-indigo"></span>
                        </h6>
                    </div>
                </div>
            </div>

            <div class="d-flex justify-content-between align-items-start align-items-sm-center mb-4 flex-column flex-sm-row">
                <div class="left d-flex align-items-center">
                    <div class="icon icon-lg shadow me-3 text-gray-700">
                        <i class="fa fa-paper-plane"></i>
                    </div>
                    <div class="text">
                        <h6 class="mb-0 d-flex align-items-center">
                            <a href="/reportvendor"><span>Vendor Report</span></a>
                            <span class="dot dot-sm ms-2 bg-indigo"></span>
                        </h6>
                    </div>
                </div>
            </div>

            <div class="d-flex justify-content-between align-items-start align-items-sm-center mb-4 flex-column flex-sm-row">
                <div class="left d-flex align-items-center">
                    <div class="icon icon-lg shadow me-3 text-gray-700">
                        <i class="fa fa-users"></i>
                    </div>
                    <div class="text">
                        <h6 class="mb-0 d-flex align-items-center">
                            <a href="/reportemployees"><span>Employees Report</span></a>
                            <span class="dot dot-sm ms-2 bg-indigo"></span>
                        </h6>
                    </div>
                </div>
            </div>

            <div class="d-flex justify-content-between align-items-start align-items-sm-center mb-4 flex-column flex-sm-row">
                <div class="left d-flex align-items-center">
                    <div class="icon icon-lg shadow me-3 text-gray-700">
                        <i class="far fa-building"></i>
                    </div>
                    <div class="text">
                        <h6 class="mb-0 d-flex align-items-center">
                            <a href="/reportdepartments"><span>Departments Report</span></a>
                            <span class="dot dot-sm ms-2 bg-indigo"></span>
                        </h6>
                    </div>
                </div>
            </div>

            <div class="d-flex justify-content-between align-items-start align-items-sm-center mb-4 flex-column flex-sm-row">
                <div class="left d-flex align-items-center">
                    <div class="icon icon-lg shadow me-3 text-gray-700">
                        <i class="fa fa-map-marker-alt"></i>
                    </div>
                    <div class="text">
                        <h6 class="mb-0 d-flex align-items-center">
                            <a href="/reportlocations"><span>Locations Report</span></a>
                            <span class="dot dot-sm ms-2 bg-indigo"></span>
                        </h6>
                    </div>
                </div>
            </div>

            <div class="d-flex justify-content-between align-items-start align-items-sm-center mb-4 flex-column flex-sm-row">
                <div class="left d-flex align-items-center">
                    <div class="icon icon-lg shadow me-3 text-gray-700">
                        <i class="fas fa-boxes"></i>
                    </div>
                    <div class="text">
                        <h6 class="mb-0 d-flex align-items-center">
                            <a href="/reportproducts"><span>Products Report</span></a>
                            <span class="dot dot-sm ms-2 bg-indigo"></span>
                        </h6>
                    </div>
                </div>
            </div>

            <div class="d-flex justify-content-between align-items-start align-items-sm-center mb-4 flex-column flex-sm-row">
                <div class="left d-flex align-items-center">
                    <div class="icon icon-lg shadow me-3 text-gray-700">
                        <i class="fas fa-box"></i>
                    </div>
                    <div class="text">
                        <h6 class="mb-0 d-flex align-items-center">
                            <a href="/reportproducttypes"><span>Product Types Report</span></a>
                            <span class="dot dot-sm ms-2 bg-indigo"></span>
                        </h6>
                    </div>
                </div>
            </div>

        </div>
    </div>

</div>

</template>

<script>

</script>

<style scoped>

.icon {
    display: flex;
    flex-shrink: 0;
    border-radius: 50%;
    align-items: center;
    justify-content: center;
}

.icon.icon-lg {
    width: 3rem;
    height: 3rem;
}

.text-gray-700 {
    color: #495057!important;
}

.me-3 {
    margin-right: 1rem!important;
}

h6 {
    font-size: .9rem;
    margin-top: 0;
    font-weight: 700;
    line-height: 1.2;
}

.dot.dot-sm {
    width: 8px;
    height: 8px;
}

.dot {
    border-radius: 50%;
    flex-grow: 0;
    flex-shrink: 0;
}

.bg-indigo {
    background-color: #6610f2!important;
}

.card {
    position: relative;
    display: flex;
    flex-direction: column;
    width: 30%;
    word-wrap: break-word;
    background-color: #fff;
    background-clip: border-box;
    border: 1px solid transparent;
    border-radius: 1rem;
    margin-left: 40%;
}

@media (max-width: 480px) {
    .card {
        width: 100%;
        margin-left: 0;
    }
}

@media (max-width: 768px) {
    .card {
        width: 100%;
        margin-left: 0;
    }
}

</style>