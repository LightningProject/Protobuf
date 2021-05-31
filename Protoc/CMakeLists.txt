set(LIBRARY_NAME protoc314)

# Find all the input files
FILE(GLOB_RECURSE LIBRARY_SRCS "${CMAKE_CURRENT_SOURCE_DIR}/*.cc")

set(PROTOC_MAIN_FILENAME "main.cc")
# exclude main files
set (EXCLUDE_FILE "${PROTOC_MAIN_FILENAME}")
foreach (TMP_PATH ${LIBRARY_SRCS})
    string (FIND ${TMP_PATH} ${EXCLUDE_FILE} EXCLUDE_FILE_FOUND)
    if (NOT ${EXCLUDE_FILE_FOUND} EQUAL -1)
        list(REMOVE_ITEM LIBRARY_SRCS ${TMP_PATH})
    endif ()
endforeach()

add_library(${LIBRARY_NAME} STATIC
        ${LIBRARY_SRCS}
        )
target_link_libraries(${LIBRARY_NAME}
        PRIVATE ${LIBRARY_PROTOBUF_3_14_0}
        )
# include additionals headers
set(ADDITIONAL_INCLUDE_DIRS
        "${CMAKE_CURRENT_SOURCE_DIR}"
        )
target_include_directories(${LIBRARY_NAME}
        PUBLIC ${ADDITIONAL_INCLUDE_DIRS}
        )

find_package(Threads)
if (CMAKE_USE_PTHREADS_INIT)
    add_definitions(-DHAVE_PTHREAD)
endif (CMAKE_USE_PTHREADS_INIT)

# Define here name of the binaries
set(EXECUTABLE_NAME protoc)
set(EXECUTABLE_NAME_PROTOC ${EXECUTABLE_NAME} CACHE STRING "protoc.exe")
set(protoc_SRC "google/protobuf/compiler/${PROTOC_MAIN_FILENAME}")

add_executable(${EXECUTABLE_NAME} ${protoc_SRC})
target_link_libraries(${EXECUTABLE_NAME}
        PRIVATE ${LIBRARY_NAME}
        ${LIBRARY_PROTOBUF_3_14_0}
        ${CMAKE_THREAD_LIBS_INIT}
        )
