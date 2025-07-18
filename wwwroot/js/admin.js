$(document).ready(function () {
    // Load levels data from API
    $.ajax({
        type: "GET",
        url: "/api/Levels",
        success: function (data) {
            // Populate levels table
            $.each(data, function (index, level) {
                var row = $("<tr>");
                row.append($("<td>").text(level.levelId));
                row.append($("<td>").text(level.levelName));
                row.append($("<td>").text(level.sequenceOrder));
                row.append($("<td>").html("<button class='btn btn-primary edit-level-btn' data-level-id='" + level.levelId + "'>Edit</button> <button class='btn btn-danger delete-level-btn' data-level-id='" + level.levelId + "'>Delete</button>"));
                $("#levels-tbody").append(row);
            });
        }
    });

    // Add new level button click event
    $("#add-level-btn").click(function () {
        // Show add level form
        var addLevelForm = $("<form>");
        addLevelForm.append($("<label>").text("Level Name:"));
        addLevelForm.append($("<input type='text' id='level-name' name='levelName'>"));
        addLevelForm.append($("<label>").text("Sequence Order:"));
        addLevelForm.append($("<input type='number' id='sequence-order' name='sequenceOrder'>"));
        addLevelForm.append($("<button class='btn btn-primary' id='save-level-btn'>Save</button>"));
        $("#levels-table").after(addLevelForm);

        // Save level button click event
        $("#save-level-btn").click(function (e) {
            e.preventDefault();
            // Get form data
            var levelName = $("#level-name").val();
            var sequenceOrder = $("#sequence-order").val();

            // Send AJAX request to add new level
            $.ajax({
                type: "POST",
                url: "/api/Levels",
                data: JSON.stringify({ levelName: levelName, sequenceOrder: sequenceOrder }),
                contentType: "application/json",
                success: function (data) {
                    // Reload levels data
                    $.ajax({
                        type: "GET",
                        url: "/api/Levels",
                        success: function (data) {
                            // Populate levels table
                            $("#levels-tbody").empty();
                            $.each(data, function (index, level) {
                                var row = $("<tr>");
                                row.append($("<td>").text(level.levelId));
                                row.append($("<td>").text(level.levelName));
                                row.append($("<td>").text(level.sequenceOrder));
                                row.append($("<td>").html("<button class='btn btn-primary edit-level-btn' data-level-id='" + level.levelId + "'>Edit</button> <button class='btn btn-danger delete-level-btn' data-level-id='" + level.levelId + "'>Delete</button>"));
                                $("#levels-tbody").append(row);
                            });
                        }
                    });
                }
            });
        });
    });

    // Edit level button click event
    $(document).on("click", ".edit-level-btn", function () {
        // Get level ID
        var levelId = $(this).data("level-id");

        // Send AJAX request to get level data
        $.ajax({
            type: "GET",
            url: "/api/Levels/" + levelId,
            success: function (data) {
                // Show edit level form
                var editLevelForm = $("<form>");
                editLevelForm.append($("<label>").text("Level Name:"));
                editLevelForm.append($("<input type='text' id='level-name' name='levelName' value='" + data.levelName + "'>"));
                editLevelForm.append($("<label>").text("Sequence Order:"));
                editLevelForm.append($("<input type='number' id='sequence-order' name='sequenceOrder' value='" + data.sequenceOrder + "'>"));
                editLevelForm.append($("<button class='btn btn-primary' id='save-level-btn'>Save</button>"));
                $("#levels-table").after(editLevelForm);

                // Save level button click event
                $("#save-level-btn").click(function (e) {
                    e.preventDefault();
                    // Get form data
                    var levelName = $("#level-name").val();
                    var sequenceOrder = $("#sequence-order").val();

                    // Send AJAX request to update level
                    $.ajax({
                        type: "PUT",
                        url: "/api/Levels/" + levelId,
                        data: JSON.stringify({ levelName: levelName, sequenceOrder: sequenceOrder }),
                        contentType: "application/json",
                        success: function (data) {
                            // Reload levels data
                            $.ajax({
                                type: "GET",
                                url: "/api/Levels",
                                success: function (data) {
                                    // Populate levels table
                                    $("#levels-tbody").empty();
                                    $.each(data, function (index, level) {
                                        var row = $("<tr>");
                                        row.append($("<td>").text(level.levelId));
                                        row.append($("<td>").text(level.levelName));
                                        row.append($("<td>").text(level.sequenceOrder));            
                                    });
                                }
                            });
                        }    
                    });
                });
            }    
        });
    });
});
